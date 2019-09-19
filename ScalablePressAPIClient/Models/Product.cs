namespace ScalablePressAPI.Models
{
    public class Product
    {
        public string name { get; set; }
        public string style { get; set; }
        public Image image { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public override string ToString() => $"{name} ({style})";
    }
}
