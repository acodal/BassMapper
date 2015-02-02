using System;
using System.Linq;
using System.Reflection;

namespace BassMapper
{
    public static class Mapper
    {
        public static TModel FromEntity<TModel, TData>(TModel vm, TData data) where TModel : IEntityModelBase<TData>
        {
            ConvertByAttribute(vm, data, true);
            vm.ConvertFromEntity(data);
            return vm;
        }

        public static TData ToEntity<TModel, TData>(TModel vm, TData data) where TModel : IEntityModelBase<TData>
        {
            ConvertByAttribute(vm, data, false);
            return vm.ConvertToEntity(data);            
        }

        public static TTo Map<TFrom, TTo>(TFrom from, TTo to) where TTo : class, new() where TFrom : class
        {
            var vm = from as IEntityModelBase<TTo>;
            if (vm != null)
            {
                ConvertByAttribute(vm, to, false);
                return vm.ConvertToEntity(to);
            }
            var vm1 = to as IEntityModelBase<TFrom>;
            if (vm1 != null)
            {
                ConvertByAttribute(vm1, from, true);
                vm1.ConvertFromEntity(from);
                return to;
            }
            throw new ArgumentException();
        }


        public static object ConvertByAttribute(object vm, object data, bool fromEntity)
        {
            foreach (var property in vm.GetType().GetProperties())
            {
                var attr = property.GetCustomAttributes(typeof(AutoMapAttribute), true)
                .Cast<AutoMapAttribute>()
                .FirstOrDefault();
                if (attr != null)
                {
                    var propertyName = string.IsNullOrEmpty(attr.PropertyName) ? property.Name : attr.PropertyName;
                    var dataClassProperty = data.GetType().GetProperty(propertyName);
                    if (dataClassProperty != null)
                    {
                        if (fromEntity)
                        {
                            SetValue(vm, data, dataClassProperty, property);
                        }
                        else if (!attr.OnlyRead)
                        {
                            SetValue(data, vm, property, dataClassProperty);
                        }
                    }
                }
            }
            return fromEntity ? vm : data;
        }

        private static void SetValue(object objectFrom, object objectTo, PropertyInfo propertyFrom, PropertyInfo propertyTo)
        {
            if (propertyFrom.PropertyType != propertyTo.PropertyType)
            {
                var valueFrom = propertyFrom.GetValue(objectTo);
                if (valueFrom != null)
                {
                    var correctTypeValue = Converter.ChangeType(valueFrom, propertyTo.PropertyType);
                    propertyTo.SetValue(objectFrom, correctTypeValue);
                }
                else if (!propertyTo.PropertyType.IsValueType)
                {
                    propertyTo.SetValue(objectFrom, null);
                }
                else
                {
                    propertyTo.SetValue(objectFrom, Activator.CreateInstance(propertyTo.PropertyType));
                }
            }
            else
            {
                propertyTo.SetValue(objectFrom, propertyFrom.GetValue(objectTo));
            }
        }
    }
}
