using System.Net.Http.Headers;

namespace ScalablePress.API
{
    public class MockupAPI : APIBase
    {
        internal MockupAPI(AuthenticationHeaderValue authHeader) : base(authHeader)
        {
        }

    }
}
