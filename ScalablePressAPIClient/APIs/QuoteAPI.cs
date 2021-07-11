using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;

namespace ScalablePress.API
{
    public class QuoteAPI : APIBase
    {
        internal QuoteAPI(AuthenticationHeaderValue authHeader, ILogger logger) : base(authHeader, logger)
        {
        }

    }
}
