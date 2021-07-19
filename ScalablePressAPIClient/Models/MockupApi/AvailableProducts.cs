using ScalablePress.API.Converters;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace ScalablePress.API.Models.MockupApi
{
    [JsonConverter(typeof(EnumValueAttributeConverter))]
    public enum AvailableProducts
    {
        [Description("Frontal view of a plain Gildan Cotton T-Shirt")] 
        [MockupTemplate("front")] 
        [EnumValue("gildan-cotton-t-shirt")] 
        gildan_cotton_t_shirt,

        [Description("Frontal view of a plain Canvas Unisex T-Shirt")] 
        [MockupTemplate("front")] 
        [EnumValue("canvas-unisex-t-shirt")] 
        canvas_unisex_t_shirt
    }
}
