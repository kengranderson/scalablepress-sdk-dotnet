using Microsoft.Extensions.Configuration;
using NLog;
using ScalablePress.API;
using ScalablePress.API.Models;
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
        IConfiguration config;
        protected Client apiClient;

        /// <summary>
        /// Before runing this test, make sure the .Net Core Secret Manager is enabled
        /// https://dev.to/bitsmonkey/protecting-sensitive-data-using-secret-manager-in-net-core--44m1
        /// and stash your ScalablePress API key there, or provide you API key any other
        /// way you want, but unless you want me to have it, don't put it in the source code...
        /// The following url gives and example of how to get the secret back out so you can use it.
        /// https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.2&tabs=windows
        /// </summary>
        public StepsBase()
        {
            ILogger logger = new LoggerAdapter(LogManager.GetCurrentClassLogger());

            var builder = new ConfigurationBuilder().
                AddUserSecrets("APIClientTestVault");

            config = builder.Build();
            var apiKey = config["ScalablePressAPI:TestAPIKey"];
            apiClient = new Client(apiKey, logger);
        }

        protected DesignRequest CreateDesignFromRandomImageAsync()
        {
            var rand = new Random();
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

        protected async Task<QuoteResponse> GetQuoteResponse(StandardQuoteRequest standardQuote, BulkQuoteRequest bulkQuote)
        {
            QuoteResponse response = null;

            if (standardQuote != null)
            {
                response = await apiClient.QuoteAPI.CreateStandardQuoteAsync(standardQuote).ConfigureAwait(false);
            }
            else if (bulkQuote != null)
            {
                response = await apiClient.QuoteAPI.CreateBulkQuoteAsync(bulkQuote).ConfigureAwait(false);
            }

            return response;
        }

        protected class Product
        {
            public string id { get; set; }
            public string designId { get; set; }
            public string title { get; set; }
            public float price { get; set; }

            public QuoteProduct ToQuoteProduct(string color, string size, int quantity) =>
                new QuoteProduct
                {
                    id = id,
                    color = color,
                    size = Enum.Parse<Sizes>(size),
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
