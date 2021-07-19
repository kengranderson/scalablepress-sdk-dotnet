using Microsoft.Extensions.Logging;
using ScalablePress.API.Models.OrderApi;
using ScalablePress.API.Models.QuoteApi;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ScalablePress.API
{
    public class OrderAPI : APIBase
    {
        internal OrderAPI(AuthenticationHeaderValue authHeader, ILogger logger) : base(authHeader, logger)
        {
        }

        /// <summary>
        /// In order to place an order, you first must make a quote request. 
        /// After a successful quote request, you will be provided with a orderToken. 
        /// This order token can then be used to place an order.
        /// </summary>
        /// <param name="orderToken"></param>
        /// <returns>Returns an order object.</returns>
        [ApiCall("order", "Post")]
        public async Task<Order> PlaceOrderAsync(string orderToken) =>
            await CallJsonAPIAsync<Order>(typeof(OrderAPI), nameof(OrderAPI.PlaceOrderAsync), postData: $"orderToken={orderToken}");

        /// <summary>
        /// After placing an order, you can reprint any item in that order using the orderId. 
        /// Specify which item by passing in an item index. 
        /// If you pass in a new address, a new product, and/or new features, the new object will replace the corresponding old object.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="item"></param>
        /// <returns>Returns a quote response object</returns>
        [ApiCall("order/{orderId}/reprint", "Post")]
        public async Task<QuoteResponse> ReprintOrderAsync(string orderId, ReprintOrderItem item) =>
            await CallJsonAPIAsync<QuoteResponse>(typeof(OrderAPI), nameof(OrderAPI.ReprintOrderAsync), nameof(orderId), orderId, item);

        /// <summary>
        /// After placing several orders you can get the status and other information on each of your orders.
        /// </summary>
        /// <returns>Returns an array of order objects.</returns>
        [ApiCall("order", "Get")]
        public async Task<IEnumerable<Order>> RetrieveOrdersAsync() =>
            await CallJsonAPIAsync<IEnumerable<Order>>(typeof(OrderAPI), nameof(OrderAPI.RetrieveOrdersAsync));

        /// <summary>
        /// Once an order has been placed, you can check on the status and other information of an order 
        /// by using the orderId field provided in the order object.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>Returns an order object.</returns>
        [ApiCall("order/{orderId}", "Get")]
        public async Task<Order> RetrieveSingleOrderAsync(string orderId) =>
            await CallJsonAPIAsync<Order>(typeof(OrderAPI), nameof(OrderAPI.RetrieveSingleOrderAsync), nameof(orderId), orderId);
    }
}
