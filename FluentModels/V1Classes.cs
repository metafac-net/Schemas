using System;

namespace FluentModelsV1
{
    [Flags]
    public enum ModelState
    {
        /// <summary>
        /// Active. Emitted during generation.
        /// </summary>
        Active = 0,

        /// <summary>
        /// Hidden. Not emitted during generation. Useful for pre-allocating items.
        /// </summary>
        Hidden = 0x01,

        /// <summary>
        /// Deprecated. Emitted during generation. Will be deleted in the future.
        /// </summary>
        Deprecated = 0x02,

        /// <summary>
        /// Deleted. Not emitted during generation.
        /// </summary>
        Deleted = Hidden | Deprecated,
    }
    [AttributeUsage(AttributeTargets.Class)]
    public class EntityAttribute : Attribute
    {
        public readonly int Tag;
        public readonly ModelState State;
        public readonly string? Reason;

        public EntityAttribute(int tag, ModelState state = ModelState.Active, string? reason = null)
        {
            if (tag <= 0) throw new ArgumentOutOfRangeException(nameof(tag), tag, "Must be > 0");
            Tag = tag;
            State = state;
            Reason = reason;
        }

        public bool Deprecated => State.HasFlag(ModelState.Deprecated);
        public bool IsRedacted => State.HasFlag(ModelState.Hidden);
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class MemberAttribute : Attribute
    {
        public readonly int Tag;
        public readonly ModelState State;
        public readonly string? Reason;

        public MemberAttribute(int tag, ModelState state = ModelState.Active, string? reason = null)
        {
            if (tag <= 0) throw new ArgumentOutOfRangeException(nameof(tag), tag, "Must be > 0");
            Tag = tag;
            State = state;
            Reason = reason;
        }

        public bool Deprecated => State.HasFlag(ModelState.Deprecated);
        public bool IsRedacted => State.HasFlag(ModelState.Hidden);
    }
    /// <summary>
    /// Marks a value type in the model as a proxy for an external type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct)]
    public class ProxyAttribute : Attribute
    {
        public readonly string ExternalName;
        public readonly string ConcreteName;

        public ProxyAttribute(string externalName, string concreteName)
        {
            ExternalName = externalName;
            ConcreteName = concreteName;
        }
    }
    /// <summary>
    /// Annotates a model entity with a name/value pair.
    /// </summary>
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
