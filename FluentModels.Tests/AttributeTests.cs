using FluentAssertions;
using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace FluentModels.UnitTests
{
    [Entity("7311f284-ae1d-4d26-96f5-5e37f7a66c3e")] internal class GoodEntity { }

    public class AttributeTests
    {
        [Fact]
        public void NormalUsageTest()
        {
            Attribute[] customAttributes = typeof(GoodEntity).GetCustomAttributes().ToArray();
            customAttributes.Length.Should().Be(1);

            Attribute customAttribute = customAttributes[0];
            customAttribute.Should().BeOfType<EntityAttribute>();

            EntityAttribute entityAttribute = (EntityAttribute)customAttribute;
            entityAttribute.UniqueId.Should().Be(new Guid("7311f284-ae1d-4d26-96f5-5e37f7a66c3e"));
        }
    }
}