using System;

namespace MetaFac.Schemas
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class RefTypeProxyAttribute<TExternal, TInternal, TConverter> : ProxyAttributeBase
        where TExternal : class
        where TInternal : class
        where TConverter : IProxyConverter<TExternal, TInternal>
    {
        public RefTypeProxyAttribute() : base(typeof(TExternal), typeof(TInternal), typeof(TConverter))
        {
        }
    }
}
