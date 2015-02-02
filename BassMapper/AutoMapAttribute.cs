using System;

namespace BassMapper
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class AutoMapAttribute : Attribute
    {
        public string PropertyName { get; private set; }
        public bool OnlyRead { get; private set; }

        public AutoMapAttribute(string propertyName, bool onlyRead = false)
        {
            PropertyName = propertyName;
            OnlyRead = onlyRead;
        }

        public AutoMapAttribute(bool onlyRead = false)
        {
            OnlyRead = onlyRead;
        }
    }
}
