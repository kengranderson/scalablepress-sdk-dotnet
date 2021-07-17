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

        public BillingAPI BillingAPI { get => Init(ref _billingAPI, () => new BillingAPI(_authHeader, _logger)); }
        public CustomizationAPI CustomizationAPI { get => Init(ref _customizationAPI, () => new CustomizationAPI(_authHeader, _logger)); }
        public DesignAPI DesignAPI { get => Init(ref _designAPI, () => new DesignAPI(_authHeader, _logger)); }
        public EventAPI EventAPI { get => Init(ref _eventAPI, () => new EventAPI(_authHeader, _logger)); }
        public MockupAPI MockupAPI { get => Init(ref _mockupAPI, () => new MockupAPI(_authHeader, _logger)); }
        public OrderAPI OrderAPI { get => Init(ref _orderAPI, () => new OrderAPI(_authHeader, _logger)); }
        public ProductAPI ProductAPI { get => Init(ref _productAPI, () => new ProductAPI(_authHeader, _logger)); }
        public QuoteAPI QuoteAPI { get => Init(ref _quoteAPI, () => new QuoteAPI(_authHeader, _logger)); }

        #region private storage and methods

        static T Init<T>(ref T variable, Func<T> setter)
        {
            if (variable == null)
            {
                variable = setter();
            }

            return variable;
        }

        BillingAPI _billingAPI;
        CustomizationAPI _customizationAPI;
        DesignAPI _designAPI;
        EventAPI _eventAPI;
        MockupAPI _mockupAPI;
        OrderAPI _orderAPI;
        ProductAPI _productAPI;
        QuoteAPI _quoteAPI;

        #endregion

    }
}
