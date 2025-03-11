using MetaFac.Schemas;
using PublicApiGenerator;
using Shouldly;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace MetaFac.Schemas.Tests
{
    public class PublicApiRegressionTests
    {
        [Fact]
        public void VersionCheck()
        {
            ThisAssembly.AssemblyVersion.ShouldBe("1.1.0.0");
        }

        [Fact]
        public async Task CheckPublicApi()
        {
            // act
            var options = new ApiGeneratorOptions()
            {
                IncludeAssemblyAttributes = false
            };
            string currentApi = typeof(EntityAttribute).Assembly.GeneratePublicApi(options);

            // assert
            await Verifier.Verify(currentApi);
        }

    }
}
