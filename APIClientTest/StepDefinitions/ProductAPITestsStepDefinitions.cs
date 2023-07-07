using System.Collections.Generic;
using TechTalk.SpecFlow;
using ScalablePress.API.Models;
using System.Threading.Tasks;
using Xunit;

namespace APIClientTest
{
    [Binding]
    class ProductAPITestsStepDefinitions : StepsBase
    {
        IEnumerable<Category> categories;
        CategoryProducts categoryProducts;
        ProductInfo productInfo;
        ProductAvailability productAvailability;
        ProductDetails productDetails;

        [Given(@"I have instantiated an API Client with a valid API key")]
        public void GivenIHaveInstantiatedAnAPIClientWithAValidAPIKey()
        {
        }

        [When(@"I call the Product Categories API")]
        public async Task WhenICallTheProductCategoriesAPI()
        {
            categories = await _apiClient.ProductAPI.ListProductCategoriesAsync().ConfigureAwait(false);
        }

        [Then(@"the result should be a list of Categories")]
        public void ThenTheResultShouldBeAListOfCategories()
        {
            Assert.NotNull(categories);
            Assert.NotEmpty(categories);
        }

        [When(@"I call the Product Category API for Category Id ""(.*)""")]
        public async Task WhenICallTheProductCategoryAPIForCategoryId(string categoryId)
        {
            categoryProducts = await _apiClient.ProductAPI.ListProductsAsync(categoryId).ConfigureAwait(false);
        }

        [Then(@"the result should be a list of Products")]
        public void ThenTheResultShouldBeAListOfProducts()
        {
            Assert.NotNull(categoryProducts);
            Assert.NotEmpty(categoryProducts.products);
        }

        [When(@"I call the Product Info API for Product Id ""(.*)""")]
        public async Task WhenICallTheProductInfoAPIForProductId(string productId)
        {
            productInfo = await _apiClient.ProductAPI.ListProductInformationAsync(productId).ConfigureAwait(false);
        }

        [Then(@"the result should be a Product Info object")]
        public void ThenTheResultShouldBeAProductInfoObject()
        {
            Assert.NotNull(productInfo);
        }

        [When(@"I call the Product Availability API for Product Id ""(.*)""")]
        public async Task WhenICallTheProductAvailabilityAPIForProductId(string productId)
        {
            productAvailability = await _apiClient.ProductAPI.ListProductAvailabilityAsync(productId).ConfigureAwait(false);
        }

        [Then(@"the result should be a Product Avalability object")]
        public void ThenTheResultShouldBeAProductAvalabilityObject()
        {
            Assert.NotNull(productAvailability);
        }

        [When(@"I call the Product Details API for Product Id ""(.*)""")]
        public async Task WhenICallTheProductDetailsAPIForProductId(string productId)
        {
            productDetails = await _apiClient.ProductAPI.ListDetailedItemInformationAsync(productId).ConfigureAwait(false);
        }

        [Then(@"the result should be a Product Details object")]
        public void ThenTheResultShouldBeAProductDetailsObject()
        {
            Assert.NotNull(productDetails);
        }
    }
}
