using System;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ScalablePress.API
{
    /// <summary>
    /// Attribute which is used to decorate methods to specify Http API calls by convention.
    /// </summary>
    public class ApiCallAttribute : Attribute
    {
        static readonly Regex rxHttpMethods = new Regex("^(GET|POST|PUT|DELETE|PATCH)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public ApiCallAttribute(string urlPattern)
        {
            UrlPattern = urlPattern;
        }

        public ApiCallAttribute(string urlPattern, string httpMethod) : this(urlPattern)
        {
            HttpMethod = httpMethod;
        }

        public ApiCallAttribute(string urlPattern, string httpMethod, string apiVersion) : this(urlPattern, httpMethod)
        {
            ApiVersion = apiVersion;
        }

        public string UrlPattern { get; }
        public string HttpMethod { get; }
        public string ApiVersion { get; } = "v2";

        public HttpMethod GetHttpMethod(MethodInfo methodInfo) 
        {
            var methodName = HttpMethod != null ? HttpMethod : rxHttpMethods.Match(methodInfo.Name)?.Groups[1].Value;
            var method = new HttpMethod(methodName);
            return method;
        }
    }
}
