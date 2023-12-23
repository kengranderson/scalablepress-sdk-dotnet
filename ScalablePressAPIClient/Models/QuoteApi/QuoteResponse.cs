using System.Collections.Generic;

namespace ScalablePress.API.Models.QuoteApi
{
    public class QuoteResponse
    {
        /// <summary>
        /// Quoted price for the order
        /// </summary>
        public float total { get; set; }

        /// <summary>
        /// Shipping component of quote total
        /// </summary>
        public float shipping { get; set; }

        /// <summary>
        /// Subtotal component of quote total
        /// </summary>
        public float subtotal { get; set; }

        /// <summary>
        /// Tax component of quote total
        /// </summary>
        public float tax { get; set; }

        /// <summary>
        /// Other fee components of quote total
        /// </summary>
        public float fees { get; set; }

        /// <summary>
        /// List of warnings as human readable strings
        /// </summary>
        public IEnumerable<string> warnings { get; set; }

        /// <summary>
        /// Array of error objects which are preventing a successful quote
        /// </summary>
        public IEnumerable<QuoteError> issues { get; set; }

        /// <summary>
        /// Array of error objects which are preventing your quote from being order-ready
        /// </summary>
        public IEnumerable<QuoteError> orderIssues { get; set; }

        /// <summary>
        /// Unique identifier which can be used to place an order, can also be used to retrieve a quote
        /// </summary>
        public string orderToken { get; set; }

        /// <summary>
        /// “test” or “live”
        /// </summary>
        public ApiModes mode { get; set; }	

        /// <summary>
        /// Bulk Quote breakdown
        /// </summary>
        public IEnumerable<BulkQuoteBreakdown> breakdown { get; set; }
    }
}
