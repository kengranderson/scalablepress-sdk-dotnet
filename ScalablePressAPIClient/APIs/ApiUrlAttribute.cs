using System;
using System.Net.Http;

namespace ScalablePressAPI
{
    public class ApiCallAttribute : Attribute
    {
        public ApiCallAttribute(string urlPattern, string method = "Get")
        {
            Method = new HttpMethod(method);
            UrlPattern = urlPattern;
        }

        public string UrlPattern { get; }
        public HttpMethod Method { get; }
    }
}
