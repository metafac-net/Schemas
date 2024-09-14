using System;

namespace MetaFac.Schemas
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MemberAttribute : Attribute
    {
        public readonly int Sequence;
        public readonly ItemState State;
        public readonly string? Reason;

        public MemberAttribute(int sequence, ItemState state = ItemState.Active, string? reason = null)
        {
            if (sequence < 0) throw new ArgumentOutOfRangeException(nameof(sequence), sequence, null);
            Sequence = sequence;
            State = state;
            Reason = reason;
        }
    }
}
