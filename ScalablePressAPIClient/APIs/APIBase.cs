#define USE_FIDDLER

using Microsoft.Extensions.Logging;
using ScalablePress.API.Converters;
using ScalablePress.API.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
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

        static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            Converters =
            {
                new EnumValueAttributeConverter(),
                new JsonStringEnumConverter()
            },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

#if USE_FIDDLER

        static readonly HttpClientHandler clientHandler = new HttpClientHandler()
        {
            Proxy = new WebProxy
            {
                Address = new Uri("http://127.0.0.1:8888")
            }
        };

        static readonly HttpClient _httpClient = new HttpClient(clientHandler)
        {
            BaseAddress = new Uri(apiBaseUrl)
        };

#else

        static readonly HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri(apiBaseUrl)
        };
#endif

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
                        if (postData.GetType() == typeof(string))
                        {
                            request.Content = new StringContent(postData.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded");
                        }
                        else
                        {
                            var jsonData = JsonSerializer.Serialize(postData, _options);
                            request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        }
                    }
                }, urlParameterName, urlParameterValue).ConfigureAwait(false);

        protected async Task<T> CallMultipartAPIAsync<T>(Type callingType, string methodName, object postData) =>
            await CallMultipartAPIAsync<T>(callingType, methodName, null, null, postData).ConfigureAwait(false);

        async Task<T> CallMultipartAPIAsync<T>(Type callingType, string methodName, string urlParameterName = null, string urlParameterValue = null, object postData = null) =>
            await CallAPIAsync<T>(callingType, methodName,
                request =>
                {
                    if (postData != null)
                    {
                        var content = CreateMultipartFormDataContent(postData);
                        request.Content = content;
                    }
                }, urlParameterName, urlParameterValue).ConfigureAwait(false);

        MultipartFormDataContent CreateMultipartFormDataContent(object postData)
        {
            var content = new MultipartFormDataContent();

            var formFields = HtmlFormSerializer.Serialize(postData);

            foreach (var key in formFields.Keys)
            {
                var value = formFields[key];

                if (value != null)
                {
                    if (value.GetType() == typeof(FileStream))
                    {
                        var fs = value as FileStream;
                        var fileValue = new StreamContent(fs);
                        content.Add(fileValue, key);
                        // WARNING: fileValue.Headers.ContentDisposition is NULL before Add() is called!
                        fileValue.Headers.ContentDisposition.FileName = $"\"{Path.GetFileName(fs.Name)}\"";
                        // WARNING: Header sequence seems to matter!
                        fileValue.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
                    }
                    else
                    {
                        var field = new StringContent(value.ToString());
                        field.Headers.Remove("Content-Type");
                        content.Add(field, key.Contains("[") ? key : $"\"{key}\"");
                    }
                }
            }

            return content;
        }

        async Task<T> CallAPIAsync<T>(Type callingType, string methodName, Action<HttpRequestMessage> contentSetter = null,
            string urlParameterName = null, string urlParameterValue = null)
        {
            try
            {
                // Get the method.
                var method = callingType.GetMethod(methodName);

                // Get the custom attribute.
                var attribute = method.GetCustomAttribute<ApiCallAttribute>();

                // Get the Http method.
                var httpMethod = attribute.GetHttpMethod(method);

                // Get the url pattern.
                var urlPattern = attribute.UrlPattern;

                // And the API version.
                var apiVersion = attribute.ApiVersion;

                // Build the url.
                var url = BuildUrl(urlPattern, urlParameterName, urlParameterValue);

                ApiCallSuccess = false;

                using (var request = new HttpRequestMessage(httpMethod, apiVersion + "/" + url))
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
