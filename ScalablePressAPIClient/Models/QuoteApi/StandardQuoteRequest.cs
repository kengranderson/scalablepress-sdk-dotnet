using System.Collections.Generic;

namespace ScalablePress.API.Models.QuoteApi
{
    public class StandardQuoteRequest
    {
        /// <summary>
        /// Type of product this design is for: screenprint, dtg, case, mug, or poster
        /// </summary>
        public PrintingTypes type { get; set; }

        /// <summary>
        /// Unique identifier for a design object to print, provided by the Design API
        /// </summary>
        public string designId { get; set; }

        /// <summary>
        /// Providing this optional sides object instead of a designId allows making quotes without creating a Design first
        /// </summary>
        public QuoteSides sides { get; set; }

        /// <summary>
        /// Array of order product objects to print on
        /// </summary>
        public IEnumerable<QuoteProduct> products { get; set; }

        /// <summary>
        /// Shipping address object
        /// </summary>
        public QuoteAddress address { get; set; }

        /// <summary>
        /// Custom features object
        /// </summary>
        public QuoteCustomFeatures features { get; set; }

        /// <summary>
        /// Optional reference name
        /// </summary>
        public string name { get; set; }	

        /// <summary>
        /// Optional whitelabel shipping data.
        /// </summary>
        public QuoteWhiteLabelData data { get; set; }

        public override string ToString() =>
            name ?? base.ToString();
    }
}
