using Core;
using EndToEndTestsApi;
using Xunit;

namespace Tests
{
    public class ValuesControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly JsonService client;

        public ValuesControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            var httpClient = factory.CreateClient();
            client = new JsonService(httpClient);
        }

        [Fact]
        public void Should_Get()
        {
            var result = client.Get("https://localhost:44363/api/values");
        }
    }
}
