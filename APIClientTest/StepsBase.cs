using Microsoft.Extensions.Configuration;
using ScalablePress.API;

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
            var builder = new ConfigurationBuilder().
                AddUserSecrets("APIClientTestVault");

            config = builder.Build();
            var apiKey = config["ScalablePressAPI:TestAPIKey"];
            apiClient = new Client(apiKey);
        }
    }
}
