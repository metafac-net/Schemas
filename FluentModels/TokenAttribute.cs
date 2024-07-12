using System;

namespace FluentModels
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum)]
    public class TokenAttribute : Attribute
    {
        public readonly string Name;
        public readonly string Value;

        public TokenAttribute(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
