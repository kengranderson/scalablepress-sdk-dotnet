using Microsoft.Extensions.Configuration;
using NLog;
using ScalablePress.API;
using ScalablePress.API.Models.DesignApi;
using ScalablePress.API.Models.QuoteApi;
using System;
using System.IO;
using System.Threading.Tasks;
using Wakanda.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace APIClientTest
{
    class StepsBase
    {
        readonly static ILogger _logger = new LoggerAdapter(LogManager.GetCurrentClassLogger());
        readonly protected IConfiguration _config;
        protected Client _apiClient;

        /// <summary>
        /// Before runing this test, make sure the .Net Core Secret Manager is enabled
        /// https://dev.to/xarjunshetty/protecting-sensitive-data-using-secret-manager-in-net-core--44m1
        /// and stash your ScalablePress API key there, or provide your API key any other
        /// way you want, but unless you want me to have it, don't put it in the source code...
        /// The following url gives and example of how to get the secret back out so you can use it.
        /// https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.2&tabs=windows
        /// </summary>
        public StepsBase()
        {
            var builder = new ConfigurationBuilder().
                AddUserSecrets("APIClientTestVault");

            _config = builder.Build();

            // Get the API key from the secret store
            var apiKey = _config["ScalablePressAPI:TestAPIKey"];

            // Create the API client
            _apiClient = new Client(apiKey, _logger);
        }

        /// <summary>
        /// Set the mode for the API client if necessary.
        /// </summary>
        /// <param name="mode"></param>
        protected void SetMode(string mode)
        {
            var configKey = $"ScalablePressAPI:{(mode == "test" ? "TestAPIKey" : "APIKey")}";
            var apiKey = _config[configKey];

            _apiClient = new Client(apiKey, _logger);
        }

        /// <summary>
        /// Create a design from a random image in the pngs folder
        /// </summary>
        /// <returns></returns>
        protected DesignRequest CreateDesignFromRandomImageAsync()
        {
            var rand = new Random();

            // Get a random image from the pngs folder (on Ken's file system)
            var files = Directory.GetFiles("C:\\BFU\\350years\\pngs", "*.png");
            var randomImageFileName = files[rand.Next(files.Length)];

            var design = new DesignRequest
            {
                name = $"Design created on {DateTime.Now}",
                type = DesignTypes.dtg,
                sides = new DesignSides
                {
                    front = new DesignSide
                    {
                        artwork = randomImageFileName,
                        aspect = 1,
                        resize = true,
                        dimensions = Dimension.Width(11),
                        position = new Position
                        {
                            horizontal = "C",
                            offset = PositionOffset.FromTop(2.5f)
                        }
                    }
                }
            };

            return design;
        }

        /// <summary>
        /// Create a standard or bulk quote
        /// </summary>
        /// <param name="standardQuote"></param>
        /// <param name="bulkQuote"></param>
        /// <returns></returns>
        protected async Task<QuoteResponse> GetQuoteResponse(StandardQuoteRequest standardQuote, BulkQuoteRequest bulkQuote)
        {
            QuoteResponse response = null;

            if (standardQuote != null)
            {
                response = await _apiClient.QuoteAPI.CreateStandardQuoteAsync(standardQuote).ConfigureAwait(false);
            }
            else if (bulkQuote != null)
            {
                response = await _apiClient.QuoteAPI.CreateBulkQuoteAsync(bulkQuote).ConfigureAwait(false);
            }

            return response;
        }

        protected class Product
        {
            public string id { get; set; }
            public string designId { get; set; }
            public string title { get; set; }
            public float price { get; set; }

            /// <summary>
            /// Convert this Product to a QuoteProduct
            /// </summary>
            /// <param name="color"></param>
            /// <param name="size"></param>
            /// <param name="quantity"></param>
            /// <returns></returns>
            public QuoteProduct ToQuoteProduct(string color, string size, int quantity) =>
                new()
                {
                    id = id,
                    color = color,
                    size = size,
                    quantity = quantity
                };
        }

        protected class ProductSizes
        {
            public string size { get; set; }
        }

        protected class Colors
        {
            public string color { get; set; }
        }
    }
}
