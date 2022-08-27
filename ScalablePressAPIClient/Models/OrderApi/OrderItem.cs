using ScalablePress.API.Models.QuoteApi;
using System.Collections.Generic;

namespace ScalablePress.API.Models.OrderApi
{
    public class OrderItem
    {
        /// <summary>
        /// Type of printing (dtg, screenprint, case, mug, or poster)
        /// </summary>
        public PrintingTypes type { get; set; }

        /// <summary>
        /// Unique identifier for a design object provided by the Design API
        /// </summary>
        public string designId { get; set; }

        /// <summary>
        /// Address object
        /// </summary>
        public QuoteAddress address { get; set; }

        /// <summary>
        /// Array of order product objects
        /// </summary>
        public IEnumerable<QuoteProduct> products { get; set; }

        /// <summary>
        /// API endpoint to Design API where information on the design can be retrieved
        /// </summary>
        public string designUrl { get; set; }

        /// <summary>
        /// Name of the last event that occurred to this particular order item
        /// </summary>
        public OrderEventTypes status { get; set; }

        /// <summary>
        /// Once the status is shipped, this will contain the tracking number of the item. Multiple order items may have the same tracking number if they are shipped together
        /// </summary>
        public string tracking { get; set; }

        /// <summary>
        /// Custom features object
        /// </summary>
        public QuoteCustomFeatures features { get; set; }

        /// <summary>
        /// Reference name provided by the user
        /// </summary>
        public string name { get; set; }

        public override string ToString() =>
            name ?? base.ToString();
    }
}
