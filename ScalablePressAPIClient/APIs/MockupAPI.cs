using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;

namespace ScalablePress.API
{
    public class MockupAPI : APIBase
    {
        internal MockupAPI(AuthenticationHeaderValue authHeader, ILogger logger) : base(authHeader, logger)
        {
        }

    }
}
