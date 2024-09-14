using FluentAssertions;
using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace MetaFac.Schemas.Tests
{
    [Entity("7311f284-ae1d-4d26-96f5-5e37f7a66c3e")]
    internal class EntityA
    {
        [Member(1)] public int Id { get; set; }
    }

    [Entity("d08e4ec2-917c-4bef-a6cf-133435e667ca", ItemState.Hidden, "Reserved")]
    internal class EntityB
    {
        [Member(1)] public int Id { get; set; }
    }

    public class AttributeTests
    {
        private EntityAttribute GetEntityAttribute(Type type)
        {
            Attribute customAttribute = type.GetCustomAttributes().Single();
            customAttribute.Should().BeOfType<EntityAttribute>();
            return (EntityAttribute)customAttribute;
        }

        [Fact]
        public void Entity01_Active()
        {
            EntityAttribute entityAttribute = GetEntityAttribute(typeof(EntityA));
            entityAttribute.UniqueId.Should().Be(new Guid("7311f284-ae1d-4d26-96f5-5e37f7a66c3e"));
            entityAttribute.State.Should().Be(ItemState.Active);
            entityAttribute.Reason.Should().BeNull();
        }

        [Fact]
        public void Entity02_Hidden()
        {
            EntityAttribute entityAttribute = GetEntityAttribute(typeof(EntityB));
            entityAttribute.UniqueId.Should().Be(new Guid("d08e4ec2-917c-4bef-a6cf-133435e667ca"));
            entityAttribute.State.Should().Be(ItemState.Hidden);
            entityAttribute.Reason.Should().Be("Reserved");
        }
    }
}
