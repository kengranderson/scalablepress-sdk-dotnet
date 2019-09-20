using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace ScalablePressAPI
{
    public class APIBase
    {
        HttpClient _httpClient;
        internal Client apiClient;

        internal APIBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task<T> CallAPIAsync<T>(Type callingType, string methodName, string parameterName = null, string parameterValue = null)
        {
            var parameters = parameterName == null ? new Type[] { } : new Type[] { typeof(string) };
            var method = callingType.GetRuntimeMethod(methodName, parameters);
            var attribute = method.GetCustomAttribute<ApiCallAttribute>();
            var urlPattern = attribute.UrlPattern;
            var url = BuildUrl(urlPattern, parameterName, parameterValue);

            using (var request = new HttpRequestMessage(attribute.Method, apiClient.ApiPath + url))
            {
                request.Headers.Authorization = apiClient.AuthHeader;

                using (var response = await _httpClient.SendAsync(request).ConfigureAwait(false))
                {
                    var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var result = JsonConvert.DeserializeObject<T>(responseContent);
                    return result;
                }
            }
        }

        string BuildUrl(string urlPattern, string parameterName = null, string parameterValue = null)
        {
            if (parameterName != null)
            {
                urlPattern = urlPattern.Replace($"{{{parameterName}}}", parameterValue);
            }
            return urlPattern;
        }
    }
}
