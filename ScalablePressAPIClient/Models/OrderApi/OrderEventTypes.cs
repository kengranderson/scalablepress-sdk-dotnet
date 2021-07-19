using ScalablePress.API.Converters;
using System.Text.Json.Serialization;

namespace ScalablePress.API.Models.OrderApi
{
    [JsonConverter(typeof(EnumValueAttributeConverter))]
    public enum OrderEventTypes
    {
        /// <summary>
        /// This is an order-ready quote, and can be used to place an order
        /// </summary>
        [EnumValue("quote")] 
        quote,

        /// <summary>
        /// Order has been placed, and is being processed
        /// </summary>
        [EnumValue("order")] 
        order,

        /// <summary>
        /// Design has been validated.
        /// </summary>
        [EnumValue("validated")] 
        validated,

        /// <summary>
        /// Order has been paid for and billed. Currently being processed for printing
        /// </summary>
        [EnumValue("paid")] 
        paid,

        /// <summary>
        /// Insufficient billing balance or credit to place the order, order is on hold until billing replenished
        /// </summary>
        [EnumValue("unpaid")] 
        unpaid,

        /// <summary>
        /// Billing successful and all items are printing
        /// </summary>
        [EnumValue("printing")] 
        printing,

        /// <summary>
        /// All items have shipped
        /// </summary>
        [EnumValue("shipped")] 
        shipped,

        /// <summary>
        /// Order has been cancelled
        /// </summary>
        [EnumValue("cancelled")] 
        cancelled,

        /// <summary>
        /// Address has been changed
        /// </summary>
        [EnumValue("address-changed")] 
        address_changed,

        /// <summary>
        /// Returned order has been inactive for two or more weeks
        /// </summary>
        [EnumValue("expired")] 
        expired
    }
}
