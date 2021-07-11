using Microsoft.Extensions.Logging;
using System;
using System.Net.Http.Headers;
using System.Text;

namespace ScalablePress.API
{
    /// <summary>
    /// The Client class encapsulates the ScalablePress API and is the only class that applications need to instantiate.
    /// </summary>
    public class Client
    {
        readonly AuthenticationHeaderValue _authHeader;
        readonly ILogger _logger;

        public Client(string apiKey, ILogger logger)
        {
            var apiKeyBytes = Encoding.ASCII.GetBytes($":{apiKey}");
            _authHeader = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(apiKeyBytes));
            _logger = logger;
        }

        public BillingAPI BillingAPI { get => new BillingAPI(_authHeader, _logger); }
        public CustomizationAPI CustomizationAPI { get => new CustomizationAPI(_authHeader, _logger); }
        public DesignAPI DesignAPI { get => new DesignAPI(_authHeader, _logger); }
        public EventAPI EventAPI { get => new EventAPI(_authHeader, _logger); }
        public MockupAPI MockupAPI { get => new MockupAPI(_authHeader, _logger); }
        public OrderAPI OrderAPI { get => new OrderAPI(_authHeader, _logger); }
        public ProductAPI ProductAPI { get => new ProductAPI(_authHeader, _logger); }
        public QuoteAPI QuoteAPI { get => new QuoteAPI(_authHeader, _logger); }
    }
}
