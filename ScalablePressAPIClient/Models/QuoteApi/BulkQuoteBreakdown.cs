namespace ScalablePress.API.Models.QuoteApi
{
    public class BulkQuoteBreakdown
    {
        /// <summary>
        /// number  Shipping component of quote total of an item
        /// </summary>
        public float shipping { get; set; }

        /// <summary>
        /// number  Printing component of quote total of an item
        /// </summary>
        public float printing { get; set; }

        /// <summary>
        /// number  Blank garment component of quote total of an item
        /// </summary>
        public float blanks { get; set; }

        /// <summary>
        /// number Other fee components of quote total of an item
        /// </summary>
        public float fees { get; set; }
    }
}
