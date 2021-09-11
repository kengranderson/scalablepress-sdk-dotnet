using System.Collections.Generic;

namespace ScalablePress.API.Models.QuoteApi
{
    public class BulkQuoteRequest
    {
        /// <summary>
        /// Optional reference name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Array of StandardQuoteRequests
        /// </summary>
        public IEnumerable<StandardQuoteRequest> items { get; set; }

        public BulkQuoteFeatures data { get; set; }
    }
}
