using Microsoft.Extensions.Configuration;
using ScalablePress.API;
using System;
using TechTalk.SpecFlow;
using NLog;
using Wakanda.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wakanda.DAL;
using ScalablePress.API.Models.QuoteApi;
using ScalablePress.API.Models;
using Xunit;
using ScalablePress.API.Models.OrderApi;
using System.Linq;

namespace APIClientTest
{
    [Binding]
    public class CrowdfundingOrdersStepDefinitions
    {
        IConfiguration _config;
        Client _apiClient;
        IEnumerable<CrowdfundingOrders> _supporterData;
        BulkQuoteRequest _bulkQuoteRequest;
        QuoteResponse _response;
        Order _order;

        int _batchSize;
        List<BulkQuoteRequest> _batchBulkQuoteRequests;
        List<QuoteResponse> _batchResponses;
        List<Order> _batchOrders;

        [Given(@"We are in ""([^""]*)"" Mode")]
        public void GivenWeAreInMode(string mode)
        {
            var settingsFolder = Path.GetDirectoryName(GetType().GetTypeInfo().Assembly.Location);
            var configKey = $"ScalablePressAPI:{(mode == "test" ? "TestAPIKey" : "APIKey")}";

            ILogger logger = new LoggerAdapter(LogManager.GetCurrentClassLogger());

            _config = new ConfigurationBuilder()
                .SetBasePath(settingsFolder)
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets("APIClientTestVault")
                .Build();

            var apiKey = _config[configKey];
            _apiClient = new Client(apiKey, logger);
        }

        [Given(@"the Crowdfunding Supporter Data is Loaded")]
        public async Task GivenTheCrowdfundingSupporterDataIsLoaded()
        {
            _supporterData = await CrowdfundingOrders.Load(_config["ConnectionString"]).ConfigureAwait(false);
        }

        [When(@"We Generate a Bulk Quote")]
        public void WhenWeGenerateABulkQuote()
        {
            _bulkQuoteRequest = new BulkQuoteRequest
            {
                name = $"Bulk Quote created at {DateTime.Now}",
                items = CreateQuotes(_supporterData),
                data = new BulkQuoteFeatures
                {
                    breakdown = true
                }
            };
        }

        [Then(@"the Quote Should be Generated")]
        public async Task ThenTheQuoteShouldBeGenerated()
        {
            _response = await _apiClient.QuoteAPI.CreateBulkQuoteAsync(_bulkQuoteRequest).ConfigureAwait(false);
            Assert.NotNull(_response.orderToken);
        }

        [Given(@"We Generate a Crowdfunding Supporter Order Quote")]
        public async Task GivenWeGenerateACrowdfundingSupporterOrderQuote()
        {
            await GivenTheCrowdfundingSupporterDataIsLoaded().ConfigureAwait(false);
            WhenWeGenerateABulkQuote();
            await ThenTheQuoteShouldBeGenerated().ConfigureAwait(false);
        }

        [When(@"We Place the Order")]
        public async Task WhenWePlaceTheOrder()
        {
            _order = await _apiClient.OrderAPI.PlaceOrderAsync(_response.orderToken).ConfigureAwait(false);
        }

        [Then(@"The Order Should be Placed")]
        public void ThenTheOrderShouldBePlaced()
        {
            Assert.NotNull(_order.orderId);
        }

        List<StandardQuoteRequest> CreateQuotes(IEnumerable<CrowdfundingOrders> supporters)
        {
            List<StandardQuoteRequest> quotes = new();

            foreach (var supporter in supporters)
            {
                if (supporter.MugCount > 0)
                {
                    var _mugQuote = new StandardQuoteRequest
                    {
                        name = $"{supporter.First_Name} {supporter.Last_Name} {supporter.MugCount} {supporter.MugTitle}",
                        address = supporter.GetAddress(),
                        designId = supporter.MugDesignSlug,
                        products = QuoteProduct.ToArray(supporter.MugProductId, supporter.Mug_Color, supporter.Mug_Size, supporter.MugCount),
                        type = Enum.Parse<PrintingTypes>(supporter.MugType)
                    };
                    quotes.Add(_mugQuote);
                }

                if (supporter.TShirtCount > 0)
                {
                    var _shirtQuote = new StandardQuoteRequest
                    {
                        name = $"{supporter.First_Name} {supporter.Last_Name} {supporter.TShirtCount} {supporter.ShirtTitle}",
                        address = supporter.GetAddress(),
                        designId = supporter.TShirtDesignSlug,
                        products = QuoteProduct.ToArray(supporter.TShirtProductId, supporter.Shirt_Color, supporter.Shirt_Size, supporter.TShirtCount),
                        type = Enum.Parse<PrintingTypes>(supporter.TShirtType)
                    };
                    quotes.Add(_shirtQuote);
                }

                if (supporter.HoodieCount > 0)
                {
                    var _hoodieQuote = new StandardQuoteRequest
                    {
                        name = $"{supporter.First_Name} {supporter.Last_Name} {supporter.HoodieCount} {supporter.HoodieTitle}",
                        address = supporter.GetAddress(),
                        designId = supporter.HoodieDesignSlug,
                        products = QuoteProduct.ToArray(supporter.HoodieProductId, supporter.Hoodie_Color, supporter.Hoodie_Size, supporter.HoodieCount),
                        type = Enum.Parse<PrintingTypes>(supporter.HoodieType)
                    };
                    quotes.Add(_hoodieQuote);
                }
            }

            return quotes;
        }

        [Given(@"We Define Batch Orders to Target (.*) Dollars")]
        public void GivenWeDefineBatchOrdersToTargetDollars(int batchSize)
        {
            _batchSize = batchSize;
        }

        [Given(@"We Generate a Crowdfunding Supporter Batch Order Quote")]
        public async Task GivenWeGenerateACrowdfundingSupporterBatchOrderQuote()
        {
            await GivenTheCrowdfundingSupporterDataIsLoaded().ConfigureAwait(false);

            _batchBulkQuoteRequests = new List<BulkQuoteRequest>();
            var quotes = CreateQuotes(_supporterData);

            while (quotes.Count > 0)
            {
                var quoteBatch = quotes.Take(_batchSize).ToList();
                var quoteRequest = new BulkQuoteRequest
                {
                    name = $"Quote Batch of {quoteBatch.Count}, {DateTime.Now}",
                    items = quoteBatch,
                    data = new BulkQuoteFeatures
                    {
                        breakdown = true
                    }
                };

                _batchBulkQuoteRequests.Add(quoteRequest);
                quotes.RemoveRange(0, quoteBatch.Count);
            }

            _batchResponses = new List<QuoteResponse>();

            foreach (var quoteRequest in _batchBulkQuoteRequests)
            {
                var response = await _apiClient.QuoteAPI.CreateBulkQuoteAsync(quoteRequest).ConfigureAwait(false);
                _batchResponses.Add(response);
            }
        }

        [When(@"We Place the Batch Order")]
        public async Task WhenWePlaceTheBatchOrder()
        {
            _batchOrders = new List<Order>();

            foreach (var response in _batchResponses)
            {
                var order = await _apiClient.OrderAPI.PlaceOrderAsync(response.orderToken).ConfigureAwait(false);
                _batchOrders.Add(order);
            }
        }

        [Then(@"The Batch of Orders Should be Placed")]
        public void ThenTheBatchOfOrdersShouldBePlaced()
        {
            Assert.All(_batchOrders, o => Assert.NotNull(o.orderId));
        }


        class CrowdfundingOrders
        {
            public string Reward { get; set; }
            public string First_Name { get; set; }
            public string Last_Name { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string Postal { get; set; }
            public string Phone { get; set; }
            public int MugCount { get; set; }
            public string MugType { get; set; }
            public string Mug_Color { get; set; }
            public string Mug_Size { get; set; }
            public string MugDesignSlug { get; set; }
            public string MugProductId { get; set; }
            public string MugTitle { get; set; }
            public int TShirtCount { get; set; }
            public string TShirtType { get; set; }
            public string Shirt_Color { get; set; }
            public string Shirt_Size { get; set; }
            public string TShirtProductId { get; set; }
            public string TShirtDesignSlug { get; set; }
            public string ShirtTitle { get; set; }
            public int HoodieCount { get; set; }
            public string HoodieType { get; set; }
            public string Hoodie_Color { get; set; }
            public string Hoodie_Size { get; set; }
            public string HoodieProductId { get; set; }
            public string HoodieDesignSlug { get; set; }
            public string HoodieTitle { get; set; }

            public QuoteAddress GetAddress() =>
                 new()
                 {
                     name = $"{First_Name} {Last_Name}",
                     address1 = Address,
                     address2 = Address2,
                     city = City,
                     state = State,
                     zip = Postal,
                     country = Country
                 };

            public static async Task<IEnumerable<CrowdfundingOrders>> Load(string connectionString) =>
                await SqlQuery.QueryAsync<CrowdfundingOrders>(connectionString, "SELECT * FROM CrowdfundingSwagOrders").ConfigureAwait(false);
        }
    }
}
