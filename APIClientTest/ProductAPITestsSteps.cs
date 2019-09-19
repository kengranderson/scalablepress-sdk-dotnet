using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using ScalablePressAPI;
using ScalablePressAPI.Models;
using System.Threading.Tasks;
using Xunit;

namespace APIClientTest
{
    [Binding]
    class ProductAPITestsSteps
    {
        IConfiguration config;
        Client apiClient;
        IEnumerable<Category> categories;
        CategoryProducts categoryProducts;
        ProductInfo productInfo;
        ProductAvailability productAvailability;
        ProductDetails productDetails;

        /// <summary>
        /// Before runing this test, make sure the .Net Core Secret Manager is enabled
        /// https://dev.to/bitsmonkey/protecting-sensitive-data-using-secret-manager-in-net-core--44m1
        /// and stash your ScalablePress API key there, or provide you API key any other
        /// way you want, but unless you want me to have it, don't put it in the source code...
        /// The following url gives and example of how to get the secret back out so you can use it.
        /// https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.2&tabs=windows
        /// </summary>
        public ProductAPITestsSteps()
        {
            var builder = new ConfigurationBuilder().
                AddUserSecrets("APIClientTestVault");

            config = builder.Build();
        }

        [Given(@"I have instantiated an API Client with a valid API key")]
        public void GivenIHaveInstantiatedAnAPIClientWithAValidAPIKey()
        {
            var apiKey = config["ScalablePressAPIKey"];
            apiClient = new Client(apiKey);
        }

        [When(@"I call the Product Categories API")]
        public void WhenICallTheProductCategoriesAPI()
        {
            categories = Task.Run(async () => await apiClient.ProductAPI.GetCategoriesAsync()).Result;
        }

        [Then(@"the result should be a list of Categories")]
        public void ThenTheResultShouldBeAListOfCategories()
        {
            Assert.NotNull(categories);
            Assert.NotEmpty(categories);
        }

        [When(@"I call the Product Category API for Category Id ""(.*)""")]
        public void WhenICallTheProductCategoryAPIForCategoryId(string categoryId)
        {
            categoryProducts = Task.Run(async () => await apiClient.ProductAPI.GetProductsAsync(categoryId)).Result;
        }

        [Then(@"the result should be a list of Products")]
        public void ThenTheResultShouldBeAListOfProducts()
        {
            Assert.NotNull(categoryProducts);
            Assert.NotEmpty(categoryProducts.products);
        }

        [When(@"I call the Product Info API for Product Id ""(.*)""")]
        public void WhenICallTheProductInfoAPIForProductId(string productId)
        {
            productInfo = Task.Run(async () => await apiClient.ProductAPI.GetProductInfoAsync(productId)).Result;
        }

        [Then(@"the result should be a Product Info object")]
        public void ThenTheResultShouldBeAProductInfoObject()
        {
            Assert.NotNull(productInfo);
        }

        [When(@"I call the Product Availability API for Product Id ""(.*)""")]
        public void WhenICallTheProductAvailabilityAPIForProductId(string productId)
        {
            productAvailability = Task.Run(async () => await apiClient.ProductAPI.GetProductAvailabilityAsync(productId)).Result;
        }

        [Then(@"the result should be a Product Avalability object")]
        public void ThenTheResultShouldBeAProductAvalabilityObject()
        {
            Assert.NotNull(productAvailability);
        }

        [When(@"I call the Product Details API for Product Id ""(.*)""")]
        public void WhenICallTheProductDetailsAPIForProductId(string productId)
        {
            productDetails = Task.Run(async () => await apiClient.ProductAPI.GetProductDetailsAsync(productId)).Result;
        }

        [Then(@"the result should be a Product Details object")]
        public void ThenTheResultShouldBeAProductDetailsObject()
        {
            Assert.NotNull(productDetails);
        }
    }
}
