using System;

namespace MetaFac.Schemas
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class EntityAttribute : Attribute
    {
        public readonly Guid UniqueId;
        public readonly ItemState State;
        public readonly string? Reason;
        // todo polymorphic tag offset: required by MessagePack etc.
        public EntityAttribute(string uniqueId, ItemState state = ItemState.Active, string? reason = null)
        {
            UniqueId = Guid.Parse(uniqueId);
            State = state;
            Reason = reason;
        }
    }
}
