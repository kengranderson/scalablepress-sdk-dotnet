namespace ScalablePress.API.Models.MockupApi
{
    public class MockupProduct
    {
        /// <summary>
        /// productId of the mockup product. See available products
        /// </summary>
        public AvailableProducts id { get; set; }

        /// <summary>
        /// Color of the product, see the Product API for available colors, some colors may be unavailable in this API
        /// </summary>
        public string color { get; set; }	
    }
}
