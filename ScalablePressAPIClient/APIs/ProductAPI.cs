using Microsoft.Extensions.Logging;
using ScalablePress.API.Models;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ScalablePress.API
{
    public class ProductAPI : APIBase
    {
        internal ProductAPI(AuthenticationHeaderValue authHeader, ILogger logger) : base(authHeader, logger)
        { 
        }

        [ApiCall("categories")]
        public async Task<IEnumerable<Category>> GetCategoriesAsync() =>
            await CallJsonAPIAsync<IEnumerable<Category>>(typeof(ProductAPI), nameof(ProductAPI.GetCategoriesAsync));

        [ApiCall("categories/{categoryId}")]
        public async Task<CategoryProducts> GetProductsAsync(string categoryId) =>
            await CallJsonAPIAsync<CategoryProducts>(typeof(ProductAPI), nameof(ProductAPI.GetProductsAsync), nameof(categoryId), categoryId);

        [ApiCall("products/{productId}")]
        public async Task<ProductInfo> GetProductInfoAsync(string productId) =>
            await CallJsonAPIAsync<ProductInfo>(typeof(ProductAPI), nameof(ProductAPI.GetProductInfoAsync), nameof(productId), productId);

        [ApiCall("products/{productId}/availability")]
        public async Task<ProductAvailability> GetProductAvailabilityAsync(string productId) =>
            await CallJsonAPIAsync<ProductAvailability>(typeof(ProductAPI), nameof(ProductAPI.GetProductAvailabilityAsync), nameof(productId), productId);

        [ApiCall("products/{productId}/items")]
        public async Task<ProductDetails> GetProductDetailsAsync(string productId) =>
            await CallJsonAPIAsync< ProductDetails>(typeof(ProductAPI), nameof(ProductAPI.GetProductDetailsAsync), nameof(productId), productId);
    }
}
