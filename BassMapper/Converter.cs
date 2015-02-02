using System;
using System.ComponentModel;

namespace BassMapper
{
    public static class Converter
    {
        public static object ChangeType(object value, Type conversionType)
        {            
            if (conversionType == null)
            {
                throw new ArgumentNullException("conversionType");
            } 

            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {                
                if (value == null)
                {
                    return null;
                }
                
                var nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }

            if (conversionType == typeof(bool) && !(value is bool))
            {
                return ToBool(value.ToString());
            }
            return Convert.ChangeType(value, conversionType);
        }

        public static bool ToBool(this string value)
        {
            if (value == null)
            {
                return false;
            }
            if (value.Equals("true", StringComparison.OrdinalIgnoreCase) || value == "1" ||
                value.Equals("yes", StringComparison.OrdinalIgnoreCase) ||
                value.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }
    }
}
