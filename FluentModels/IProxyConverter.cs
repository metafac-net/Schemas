namespace MetaFac.Schemas
{
    public interface IProxyConverter<TExternal, TInternal>
    {
        static abstract TExternal? ToExternal(TInternal? value);
        static abstract TInternal? ToInternal(TExternal? value);
    }
}
