using System;

namespace ScalablePress.API.Models.OrderApi
{
    public class OrderEvent
    {
        /// <summary>
        /// Name of the event (quote, order, etc.)
        /// </summary>
        public OrderEventTypes name { get; set; }

        /// <summary>
        /// Description of the event
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Optional additional data. Event examples
        /// </summary>
        public OrderEventMetaData meta { get; set; }

        /// <summary>
        /// Time at which the event occurred
        /// </summary>
        public DateTime createdAt { get; set; }	
    }
}
