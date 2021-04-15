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

        public Client(string apiKey)
        {
            var apiKeyBytes = Encoding.ASCII.GetBytes($":{apiKey}");
            _authHeader = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(apiKeyBytes));
        }

        public BillingAPI BillingAPI { get => new BillingAPI(_authHeader); }
        public CustomizationAPI CustomizationAPI { get => new CustomizationAPI(_authHeader); }
        public DesignAPI DesignAPI { get => new DesignAPI(_authHeader); }
        public EventAPI EventAPI { get => new EventAPI(_authHeader); }
        public MockupAPI MockupAPI { get => new MockupAPI(_authHeader); }
        public OrderAPI OrderAPI { get => new OrderAPI(_authHeader); }
        public ProductAPI ProductAPI { get => new ProductAPI(_authHeader); }
        public QuoteAPI QuoteAPI { get => new QuoteAPI(_authHeader); }
    }
}
