using System.Net.Http.Headers;

namespace ScalablePress.API
{
    public class QuoteAPI : APIBase
    {
        internal QuoteAPI(AuthenticationHeaderValue authHeader) : base(authHeader)
        {
        }

    }
}
