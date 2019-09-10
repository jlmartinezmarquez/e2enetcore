using Core;
using EndToEndTestsApi;
using EndToEndTestsApi.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace Tests
{
    public class ValuesControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly JsonService client;

        private const string BaseUri = "https://localhost:44363";

        public ValuesControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            var httpClient = factory.CreateClient();
            client = new JsonService(httpClient);
        }

        [Fact]
        public async Task Should_Get()
        {
            (var _, var actual) = await client.GetAsync<IEnumerable<Thing>>($"{BaseUri}/api/values");
            Assert.NotNull(actual);
            Assert.True(actual.Count() == 1);
        }
    }
}
