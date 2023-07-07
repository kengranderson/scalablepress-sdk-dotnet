using Microsoft.Extensions.Logging;
using ScalablePress.API.Models.MockupApi;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ScalablePress.API
{
    public class MockupAPI : APIBase
    {
        internal MockupAPI(AuthenticationHeaderValue authHeader, ILogger logger) : base(authHeader, logger)
        {
        }

        /// <summary>
        /// Provide the details of your design and product in order to receive an URL of rendered mockup image.
        /// </summary>
        /// <param name="mockup"></param>
        /// <returns></returns>
        [ApiCall("mockup", "Post", "v3")]
        public async Task<MockupResponse> CreateMockupAsync(Mockup mockup) =>
            await CallMultipartAPIAsync<MockupResponse>(typeof(MockupAPI), nameof(CreateMockupAsync), mockup).ConfigureAwait(false);

    }
}
