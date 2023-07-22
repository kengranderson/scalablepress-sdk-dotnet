using System.Collections.Generic;

namespace ScalablePress.API.Models
{
    public class SizeInfo
    {
        public int quantity { get; set; }
        public float price { get; set; }
        public float weight { get; set; }
        public string size { get; set; }
        public string color { get; set; }
        public string GTIN { get; set; }
        public IEnumerable<string> tags { get; set; }
        public override string ToString() => $"{quantity} ({price})";
    }
}
