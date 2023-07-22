using System.Collections.Generic;

namespace ScalablePress.API.Models
{
    public class Color
    {
        public string name { get; set; }
        public string hex { get; set; }
        public IEnumerable<Image> images { get; set; }
        public IEnumerable<string> sizes { get; set; }
        public override string ToString() => $"{name}";
    }
}
