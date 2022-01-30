namespace ScalablePress.API.Models.QuoteApi
{
    public class QuoteProduct
    {
        /// <summary>
        /// productId of the product you wish to order, retrieved from the Product API, this product must be compatible with the design provided
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Color of the product, see the Product API for available colors
        /// </summary>
        public string color { get; set; }

        /// <summary>
        /// Size of the product, see the Product API for available sizes
        /// </summary>
        public string size { get; set; }

        /// <summary>
        /// Quantity of this product/color/size to order
        /// </summary>
        public int quantity { get; set; }	
    }
}
