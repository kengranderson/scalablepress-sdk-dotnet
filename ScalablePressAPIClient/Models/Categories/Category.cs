namespace ScalablePress.API.Models
{
    public class Category
    {
        public string type { get; set; }
        public string name { get; set; }
        public string family { get; set; }
        public string url { get; set; }
        public string categoryId { get; set; }
        public override string ToString() => $"{name} ({type})";
    }
}
