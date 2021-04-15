using System.Net.Http.Headers;

namespace ScalablePress.API
{
    public class BillingAPI : APIBase
    {
        internal BillingAPI(AuthenticationHeaderValue authHeader) : base(authHeader)
        {
        }

    }
}
