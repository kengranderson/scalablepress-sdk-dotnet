using ScalablePress.API.Converters;
using System.Text.Json.Serialization;

namespace ScalablePress.API.Models.OrderApi
{
    [JsonConverter(typeof(EnumValueAttributeConverter))]
    public enum ItemEventTypes
    {
        /// <summary>
        /// Item is currently printing
        /// </summary>
        [EnumValue("printing")] 
        printing,

        /// <summary>
        /// Item has shipped
        /// </summary>
        [EnumValue("shipped")] 
        shipped,

        /// <summary>
        /// Item has been cancelled
        /// </summary>
        [EnumValue("cancelled")] 
        cancelled,

        /// <summary>
        /// Item is on hold
        /// </summary>
        [EnumValue("hold")] 
        hold
    }
}
