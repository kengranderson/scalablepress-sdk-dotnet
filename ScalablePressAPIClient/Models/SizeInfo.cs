namespace ScalablePressAPI.Models
{
    public class SizeInfo
    {
        public int quantity { get; set; }
        public int price { get; set; }
        public float weight { get; set; }
        public string size { get; set; }
        //public string color { get; set; }
        public string GTIN { get; set; }
        public override string ToString() => $"{quantity} ({price})";
    }
}
