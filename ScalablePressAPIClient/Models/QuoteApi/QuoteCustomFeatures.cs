namespace ScalablePress.API.Models.QuoteApi
{
    public class QuoteCustomFeatures
    {
        /// <summary>
        /// Shipping service code. Available service codes
        /// </summary>
        public QuoteShippingOptions shipping { get; set; }

        /// <summary>
        /// Absolute URL for a PDF packing slip
        /// </summary>
        public string packing { get; set; }

        public override string ToString() =>
            shipping.ToString();
    }
}
