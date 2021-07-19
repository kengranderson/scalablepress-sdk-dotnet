using Microsoft.Extensions.Configuration;
using NLog;
using ScalablePress.API;
using ScalablePress.API.Models.DesignApi;
using System;
using System.IO;
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
    }
}
