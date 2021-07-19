using ScalablePress.API.Converters;
using System.Text.Json.Serialization;

namespace ScalablePress.API.Models.MockupApi
{
    [JsonConverter(typeof(EnumValueAttributeConverter))]
    public enum AvailableBackgrounds
    {
        [EnumValue("brick")] 
        brick,

        [EnumValue("ceramic-tiles")] 
        ceramic_tiles,

        [EnumValue("radiate")] 
        radiate,

        [EnumValue("light-wood-planks")] 
        light_wood_planks,

        [EnumValue("aged-wood-planks")] 
        aged_wood_planks,

        [EnumValue("dark-wood")] 
        dark_wood,

        [EnumValue("grey-wood")] 
        grey_wood,

        [EnumValue("rough-wood")] 
        rough_wood
    }
}
