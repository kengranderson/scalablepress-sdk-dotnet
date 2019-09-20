using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ScalablePressAPI.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Sizes
    {
        sml,
        med,
        lrg,
        xlg,
        xxl,
        xxxl,
        xxxxl,
        xxxxxl
    }
}
