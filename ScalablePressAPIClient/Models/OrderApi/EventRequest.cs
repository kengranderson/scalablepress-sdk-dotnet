namespace ScalablePress.API.Models.OrderApi
{
    public class EventRequest
    {
        /// <summary>
        /// Unique id for the affected order
        /// </summary>
        public string orderId { get; set; }

        /// <summary>
        /// Event object
        /// </summary>
        public OrderEvent @event { get; set; }
    }
}
