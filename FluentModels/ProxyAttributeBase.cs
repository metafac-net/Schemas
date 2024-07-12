using System;

namespace FluentModels
{
    public abstract class ProxyAttributeBase : Attribute
    {
        public readonly string ExternalName;
        public readonly string InternalName;
        public readonly string ConverterTypeName;

        protected ProxyAttributeBase(Type externalType, Type internalType, Type converterType)
        {
            ExternalName = externalType.FullName ?? throw new ArgumentOutOfRangeException(nameof(externalType), externalType, null);
            InternalName = internalType.FullName ?? throw new ArgumentOutOfRangeException(nameof(internalType), internalType, null);
            ConverterTypeName = converterType.FullName ?? throw new ArgumentOutOfRangeException(nameof(converterType), converterType, null);
        }
    }
}
