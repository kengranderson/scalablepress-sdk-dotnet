using System.Net.Http.Headers;

namespace ScalablePress.API
{
    public class OrderAPI : APIBase
    {
        internal OrderAPI(AuthenticationHeaderValue authHeader) : base(authHeader)
        {
        }

    }
}
