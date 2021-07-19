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

        /// <summary>
        /// Get a list of available product categories. No arguments are needed for this request.
        /// </summary>
        /// <returns>Returns an array with all available category objects.</returns>
        [ApiCall("categories", "Get")]
        public async Task<IEnumerable<Category>> ListProductCategoriesAsync() =>
            await CallJsonAPIAsync<IEnumerable<Category>>(typeof(ProductAPI), nameof(ProductAPI.ListProductCategoriesAsync));

        /// <summary>
        /// Specify a category id to receive category information and a list of products in that category.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>Returns a category object which now contains an array of product overview objects.</returns>
        [ApiCall("categories/{categoryId}", "Get")]
        public async Task<CategoryProducts> ListProductsAsync(string categoryId) =>
            await CallJsonAPIAsync<CategoryProducts>(typeof(ProductAPI), nameof(ProductAPI.ListProductsAsync), nameof(categoryId), categoryId);

        /// <summary>
        /// Specify a product id to receive product information. This information could include the following:
        /// Description
        /// Materials
        /// Brand
        /// Style Code
        /// Color list
        /// Size Range
        /// Product Photos
        /// The productId, color name, (colors.#.name), and size (colors.#.sizes.#) are used when placing an order.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Returns a product object.</returns>
        [ApiCall("products/{productId}", "Get")]
        public async Task<ProductInfo> ListProductInformationAsync(string productId) =>
            await CallJsonAPIAsync<ProductInfo>(typeof(ProductAPI), nameof(ProductAPI.ListProductInformationAsync), nameof(productId), productId);

        /// <summary>
        /// Specify a product id to receive product availability information. 
        /// If a color/size combination is not specified then it is unavailable.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Returns a product availability object.</returns>
        [ApiCall("products/{productId}/availability", "Get")]
        public async Task<ProductAvailability> ListProductAvailabilityAsync(string productId) =>
            await CallJsonAPIAsync<ProductAvailability>(typeof(ProductAPI), nameof(ProductAPI.ListProductAvailabilityAsync), nameof(productId), productId);

        /// <summary>
        /// Specify a product id to receive product information. For each color of the product, this information includes the following:
        /// Quantity
        /// Price
        /// Weight
        /// Size
        /// Color
        /// Global Trade Item Number
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Returns an item object</returns>
        [ApiCall("products/{productId}/items", "Get")]
        public async Task<ProductDetails> ListDetailedItemInformationAsync(string productId) =>
            await CallJsonAPIAsync<ProductDetails>(typeof(ProductAPI), nameof(ProductAPI.ListDetailedItemInformationAsync), nameof(productId), productId);
    }
}
