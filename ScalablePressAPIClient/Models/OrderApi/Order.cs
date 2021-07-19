using System;
using System.Collections.Generic;

namespace ScalablePress.API.Models.OrderApi
{
    public class Order
    {
        /// <summary>
        /// Name of the last event that occurred
        /// </summary>
        public OrderEventTypes status { get; set; }

        /// <summary>
        /// Price for the order
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
        /// Unique identifier which can be used to place an order, can also be used to retrieve a quote
        /// </summary>
        public string orderToken { get; set; }

        /// <summary>
        /// Time at which order object was created
        /// </summary>
        public DateTime createdAt { get; set; }

        /// <summary>
        /// Array of item objects
        /// </summary>
        public IEnumerable<OrderItem> items { get; set; }

        /// <summary>
        /// Array of event objects
        /// </summary>
        public IEnumerable<OrderEvent> events { get; set; }

        /// <summary>
        /// Unique id for the order, can be used to get order information using the Order API (only exists when an order has been placed)
        /// </summary>
        public string orderId { get; set; }

        /// <summary>
        /// test or live
        /// </summary>
        public ApiModes mode { get; set; }

        /// <summary>
        /// Array of warningIDs
        /// </summary>
        public IEnumerable<string> warnings { get; set; }	
    }
}
