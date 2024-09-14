using System;

namespace MetaFac.Schemas
{
    [AttributeUsage(AttributeTargets.Enum, AllowMultiple = false)]
    public class EnumTypeAttribute : Attribute
    {
        public readonly Guid UniqueId;
        public readonly ItemState State;
        public readonly string? Reason;

        public EnumTypeAttribute(string uniqueId, ItemState state = ItemState.Active, string? reason = null)
        {
            UniqueId = Guid.Parse(uniqueId);
            State = state;
            Reason = reason;
        }
    }
}
