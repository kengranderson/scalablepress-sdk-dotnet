using System.Collections.Generic;
using TechTalk.SpecFlow;
using ScalablePress.API.Models;
using System.Threading.Tasks;
using Xunit;

namespace APIClientTest
{
    [Binding]
    class ProductAPITestsSteps : StepsBase
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
        public void WhenICallTheProductCategoriesAPI()
        {
            categories = Task.Run(async () => await apiClient.ProductAPI.GetCategoriesAsync().ConfigureAwait(false)).Result;
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
            categoryProducts = Task.Run(async () => await apiClient.ProductAPI.GetProductsAsync(categoryId).ConfigureAwait(false)).Result;
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
            productInfo = Task.Run(async () => await apiClient.ProductAPI.GetProductInfoAsync(productId).ConfigureAwait(false)).Result;
        }

        [Then(@"the result should be a Product Info object")]
        public void ThenTheResultShouldBeAProductInfoObject()
        {
            Assert.NotNull(productInfo);
        }

        [When(@"I call the Product Availability API for Product Id ""(.*)""")]
        public void WhenICallTheProductAvailabilityAPIForProductId(string productId)
        {
            productAvailability = Task.Run(async () => await apiClient.ProductAPI.GetProductAvailabilityAsync(productId).ConfigureAwait(false)).Result;
        }

        [Then(@"the result should be a Product Avalability object")]
        public void ThenTheResultShouldBeAProductAvalabilityObject()
        {
            Assert.NotNull(productAvailability);
        }

        [When(@"I call the Product Details API for Product Id ""(.*)""")]
        public void WhenICallTheProductDetailsAPIForProductId(string productId)
        {
            productDetails = Task.Run(async () => await apiClient.ProductAPI.GetProductDetailsAsync(productId).ConfigureAwait(false)).Result;
        }

        [Then(@"the result should be a Product Details object")]
        public void ThenTheResultShouldBeAProductDetailsObject()
        {
            Assert.NotNull(productDetails);
        }
    }
}
