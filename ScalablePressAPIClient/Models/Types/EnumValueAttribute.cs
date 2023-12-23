using System;

namespace ScalablePress.API.Models
{
    internal class EnumValueAttribute : Attribute
    {
        public EnumValueAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
