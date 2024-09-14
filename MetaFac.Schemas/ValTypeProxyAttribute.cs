using System;

namespace MetaFac.Schemas
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ValTypeProxyAttribute<TExternal, TInternal, TConverter> : ProxyAttributeBase
        where TExternal : struct
        where TInternal : struct
        where TConverter : IProxyConverter<TExternal, TInternal>
    {
        public ValTypeProxyAttribute() : base(typeof(TExternal), typeof(TInternal), typeof(TConverter))
        {
        }
    }
}
