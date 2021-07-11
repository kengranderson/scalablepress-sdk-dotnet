using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;

namespace ScalablePress.API
{
    public class EventAPI : APIBase
    {
        internal EventAPI(AuthenticationHeaderValue authHeader, ILogger logger) : base(authHeader, logger)
        {
        }

    }
}
