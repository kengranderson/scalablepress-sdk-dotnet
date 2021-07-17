using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;

namespace ScalablePress.API
{
    public class CustomizationAPI : APIBase
    {
        internal CustomizationAPI(AuthenticationHeaderValue authHeader, ILogger logger) : base(authHeader, logger)
        {
        }

    }
}
