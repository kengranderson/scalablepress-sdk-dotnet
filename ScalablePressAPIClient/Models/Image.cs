namespace ScalablePressAPI.Models
{
    public class Image
    {
        public string url { get; set; }
        public string label { get; set; }
        public override string ToString() => $"{label} ({url})";
    }
}
