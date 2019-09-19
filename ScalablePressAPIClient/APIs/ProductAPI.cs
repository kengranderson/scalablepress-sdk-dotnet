using ScalablePressAPI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ScalablePressAPI
{
    public class ProductAPI : APIBase
    {
        internal ProductAPI(HttpClient httpClient) : base(httpClient)
        {
        }

        [ApiCall("categories")]
        public async Task<IEnumerable<Category>> GetCategoriesAsync() =>
            await CallAPIAsync<IEnumerable<Category>>(typeof(ProductAPI), nameof(ProductAPI.GetCategoriesAsync));

        [ApiCall("categories/{categoryId}")]
        public async Task<CategoryProducts> GetProductsAsync(string categoryId) =>
            await CallAPIAsync<CategoryProducts>(typeof(ProductAPI), nameof(ProductAPI.GetProductsAsync), nameof(categoryId), categoryId);

        [ApiCall("products/{productId}")]
        public async Task<ProductInfo> GetProductInfoAsync(string productId) =>
            await CallAPIAsync<ProductInfo>(typeof(ProductAPI), nameof(ProductAPI.GetProductInfoAsync), nameof(productId), productId);

        [ApiCall("products/{productId}/availability")]
        public async Task<ProductAvailability> GetProductAvailabilityAsync(string productId) =>
            await CallAPIAsync<ProductAvailability>(typeof(ProductAPI), nameof(ProductAPI.GetProductAvailabilityAsync), nameof(productId), productId);

        [ApiCall("products/{productId}/items")]
        public async Task<ProductDetails> GetProductDetailsAsync(string productId) =>
            await CallAPIAsync< ProductDetails>(typeof(ProductAPI), nameof(ProductAPI.GetProductDetailsAsync), nameof(productId), productId);
    }
}
