using Microsoft.Extensions.Logging;
using ScalablePress.API.Models.OrderApi;
using ScalablePress.API.Models.QuoteApi;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ScalablePress.API
{
    public class QuoteAPI : APIBase
    {
        internal QuoteAPI(AuthenticationHeaderValue authHeader, ILogger logger) : base(authHeader, logger)
        {
        }

        /// <summary>
        /// The standard quote API allows a quote for a single design printed on one or more products, 
        /// shipped to a single address.
        /// </summary>
        /// <param name="quote"></param>
        /// <returns>Returns a quote response object.</returns>
        [ApiCall("quote", "Post")]
        public async Task<QuoteResponse> CreateStandardQuoteAsync(StandardQuoteRequest quote) =>
            await CallJsonAPIAsync<QuoteResponse>(typeof(QuoteAPI), nameof(CreateStandardQuoteAsync), postData: quote).ConfigureAwait(false);

        /// <summary>
        /// The bulk quote API allows receiving quotes for printing multiple designs, items, and shipping to multiple addresses. 
        /// Discounts will automatically be applied whenever possible.
        /// </summary>
        /// <param name="quote"></param>
        /// <returns>Returns a quote response object.</returns>
        [ApiCall("quote/bulk", "Post")]
        public async Task<QuoteResponse> CreateBulkQuoteAsync(BulkQuoteRequest quote) =>
            await CallJsonAPIAsync<QuoteResponse>(typeof(QuoteAPI), nameof(CreateBulkQuoteAsync), postData: quote).ConfigureAwait(false);

        /// <summary>
        /// After you have made a successful order-ready quote, you will be provided with an orderToken. 
        /// This order token can be used to retrieve the quote it is associated with.
        /// </summary>
        /// <param name="orderToken"></param>
        /// <returns>Returns an order object.</returns>
        [ApiCall("quote/{orderToken}", "Get")]
        public async Task<Order> RetrieveQuoteAsync(string orderToken) =>
            await CallJsonAPIAsync<Order>(typeof(QuoteAPI), nameof(RetrieveQuoteAsync), nameof(orderToken), orderToken);
    }
}
