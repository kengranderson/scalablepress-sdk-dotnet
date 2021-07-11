using Microsoft.Extensions.Logging;
using ScalablePress.API.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Wakanda.FormSerializer;

namespace ScalablePress.API
{
    public class APIBase
    {
        const string apiBaseUrl = "https://api.scalablepress.com";
        const string apiPath = "v2/";

        static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() }
        };

        static readonly HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri(apiBaseUrl)
        };

        readonly AuthenticationHeaderValue _authHeader;
        readonly ILogger _logger;

        protected APIBase(AuthenticationHeaderValue authHeader, ILogger logger)
        {
            _authHeader = authHeader;
            _logger = logger;
        }

        public bool ApiCallSuccess { get; private set; }
        internal BadRequest BadRequest { get; private set; }

        protected async Task<T> CallJsonAPIAsync<T>(Type callingType, string methodName) =>
            await CallAPIAsync<T>(callingType, methodName).ConfigureAwait(false);

        //protected async Task<T> CallJsonAPIAsync<T>(Type callingType, string methodName, object postData) =>
        //    await CallJsonAPIAsync<T>(callingType, methodName, null, null, postData).ConfigureAwait(false);

        protected async Task<T> CallJsonAPIAsync<T>(Type callingType, string methodName, string urlParameterName = null, string urlParameterValue = null, object postData = null) =>
            await CallAPIAsync<T>(callingType, methodName,
                request =>
                {
                    if (postData != null)
                    {
                        var jsonData = JsonSerializer.Serialize(postData, _options);
                        request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    }
                }, urlParameterName, urlParameterValue, postData).ConfigureAwait(false);


        protected async Task<T> CallMultipartAPIAsync<T>(Type callingType, string methodName, object postData) =>
            await CallMultipartAPIAsync<T>(callingType, methodName, null, null, postData).ConfigureAwait(false);

        protected async Task<T> CallMultipartAPIAsync<T>(Type callingType, string methodName, string urlParameterName = null, string urlParameterValue = null, object postData = null) =>
            await CallAPIAsync<T>(callingType, methodName,
                request =>
                {
                    if (postData != null)
                    {
                        var content = CreateMultipartFormDataContent(postData);
                        request.Content = content;
                    }
                }, urlParameterName, urlParameterValue, postData).ConfigureAwait(false);

        MultipartFormDataContent CreateMultipartFormDataContent(object postData)
        {
            var content = new MultipartFormDataContent();
            var formFields = Serializer.Serialize(postData);

            foreach (var key in formFields.Keys)
            {
                content.Add(new StringContent(formFields[key]), key);
            }

            return content;
        }

        async Task<T> CallAPIAsync<T>(Type callingType, string methodName, Action<HttpRequestMessage> contentSetter = null, 
            string urlParameterName = null, string urlParameterValue = null, object postData = null)
        {
            try
            {
                // Get the method.
                var method = callingType.GetMethod(methodName);

                // Get the custom attribute.
                var attribute = method.GetCustomAttribute<ApiCallAttribute>();

                // Get the url pattern.
                var urlPattern = attribute.UrlPattern;

                // Build the url.
                var url = BuildUrl(urlPattern, urlParameterName, urlParameterValue);

                ApiCallSuccess = false;

                using (var request = new HttpRequestMessage(attribute.Method, apiPath + url))
                {
                    request.Headers.Authorization = _authHeader;
                    contentSetter?.Invoke(request);

                    using (var response = await _httpClient.SendAsync(request).ConfigureAwait(false))
                    {
                        var responseContent = await ReadAsStringAsync(response).ConfigureAwait(false);

                        if (response.IsSuccessStatusCode)
                        {
                            ApiCallSuccess = true;
                            var result = JsonSerializer.Deserialize<T>(responseContent, _options);
                            return result;
                        }
                        else
                        {
                            BadRequest = GetBadRequest(responseContent);
                            return default;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return default;
            }
        }

        static Regex rxUTF8 = new Regex("utf8|UTF-8", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        static async Task<string> ReadAsStringAsync(HttpResponseMessage response)
        {
            using (var content = response.Content)
            {
                var contentType = content.Headers.First(h => h.Key.Equals("Content-Type"));
                var rawEncoding = contentType.Value.First();

                if (rxUTF8.IsMatch(rawEncoding))
                {
                    var bytes = await content.ReadAsByteArrayAsync().ConfigureAwait(false);
                    return Encoding.UTF8.GetString(bytes);
                }
                else
                {
                    var html = await content.ReadAsStringAsync().ConfigureAwait(false);
                    return html;
                }
            }
        }

        /// <summary>
        /// Builds a url from a pair of mustachioed key/value parameters in a string
        /// </summary>
        /// <param name="urlPattern"></param>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        string BuildUrl(string urlPattern, string parameterName = null, string parameterValue = null)
        {
            if (parameterName != null)
            {
                urlPattern = urlPattern.Replace($"{{{parameterName}}}", parameterValue);
            }
            return urlPattern;
        }

        BadRequest GetBadRequest(string jsonResponse)
        {
            var result = JsonSerializer.Deserialize<BadRequest>(jsonResponse, _options);
            return result;
        }
    }
}
