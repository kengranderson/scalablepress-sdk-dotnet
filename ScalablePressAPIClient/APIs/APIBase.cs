﻿//#define USE_FIDDLER

using Microsoft.Extensions.Logging;
using ScalablePress.API.Converters;
using ScalablePress.API.Models;
using System;
using System.Collections.Generic;
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

        static readonly JsonSerializerOptions _options = new()
        {
            Converters =
            {
                new EnumValueAttributeConverter(),
                new JsonStringEnumConverter()
            },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

#if USE_FIDDLER

        static readonly HttpClientHandler clientHandler = new()
        {
            Proxy = new WebProxy
            {
                Address = new Uri("http://127.0.0.1:8888")
            }
        };

        static readonly HttpClient _httpClient = new(clientHandler)
        {
            BaseAddress = new Uri(apiBaseUrl)
        };

#else

        static readonly HttpClient _httpClient = new()
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
                            var formData = postData.ToString();
                            _logger.LogTrace($"CallJsonAPIAsync: formData= {formData}");
                            request.Content = new StringContent(formData, Encoding.UTF8, "application/x-www-form-urlencoded");
                        }
                        else
                        {
                            var jsonData = JsonSerializer.Serialize(postData, _options);
                            _logger.LogTrace($"CallJsonAPIAsync: jsonData= {jsonData}");
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

            // Serialize the form fields using the Wakanda.FormSerializer library.
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
                _logger.LogTrace($"CallAPIAsync: httpMethod= {httpMethod}");

                // Get the url pattern.
                var urlPattern = attribute.UrlPattern;
                _logger.LogTrace($"CallAPIAsync: urlPattern= {urlPattern}");

                // And the API version.
                var apiVersion = attribute.ApiVersion;
                _logger.LogTrace($"CallAPIAsync: apiVersion= {apiVersion}");

                // Build the url.
                var url = attribute.GetUrl(urlParameterName, urlParameterValue);
                _logger.LogTrace($"CallAPIAsync: url= {url}");

                ApiCallSuccess = false;

                using (var request = new HttpRequestMessage(httpMethod, apiVersion + "/" + url))
                {
                    request.Headers.Authorization = _authHeader;
                    _logger.LogTrace($"CallAPIAsync: Authorization= {_authHeader}");
                    contentSetter?.Invoke(request);

                    using (var response = await _httpClient.SendAsync(request).ConfigureAwait(false))
                    {
                        var responseContent = await ReadAsStringAsync(response).ConfigureAwait(false);

                        _logger.LogTrace($"CallAPIAsync: IsSuccessStatusCode= {response.IsSuccessStatusCode}");
                        _logger.LogTrace($"CallAPIAsync: responseContent= {responseContent}");

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
                _logger?.LogError(ex, ex.Message);
                throw;
            }
        }

        static Regex rxUTF8 = new Regex("utf8|UTF-8", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        async Task<string> ReadAsStringAsync(HttpResponseMessage response)
        {
            using (var content = response.Content)
            {
                string responseContent;

                if (IsUTF8(content))
                {
                    var bytes = await content.ReadAsByteArrayAsync().ConfigureAwait(false);
                    responseContent = Encoding.UTF8.GetString(bytes);
                }
                else
                {
                    var html = await content.ReadAsStringAsync().ConfigureAwait(false);
                    responseContent = html;
                }

                _logger.LogTrace($"ReadAsStringAsync: responseContent= {responseContent}");
                return responseContent;
            }
        }

        static bool IsUTF8(HttpContent content)
        {
            if (content.Headers.TryGetValues("Content-Type", out IEnumerable<string> headers))
            {
                var isutf8 = headers.Any(h => rxUTF8.IsMatch(h));
                return isutf8;
            }

            return false;
        }

        BadRequest GetBadRequest(string jsonResponse)
        {
            var result = JsonSerializer.Deserialize<BadRequest>(jsonResponse, _options);
            return result;
        }
    }
}
