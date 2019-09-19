using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ScalablePressAPI
{
    public class Client
    {
        const string apiBaseUrl = "https://api.scalablepress.com";
        internal AuthenticationHeaderValue AuthHeader;

        static readonly HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri(apiBaseUrl)
        };

        public Client(string apiKey)
        {
            var apiKeyBytes = Encoding.ASCII.GetBytes($":{apiKey}");
            AuthHeader = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(apiKeyBytes));

            ProductAPI.apiClient = this;
        }

        internal string ApiPath { get; } = "v2/";
        public ProductAPI ProductAPI { get; } = new ProductAPI(httpClient);
    }
}
