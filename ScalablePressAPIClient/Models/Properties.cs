namespace ScalablePressAPI.Models
{
    public class Properties
    {
        public string brand { get; set; }
        public string material { get; set; }
        public string style { get; set; }
        public override string ToString() => $"{brand} / {material} / {style}";
    }
}
