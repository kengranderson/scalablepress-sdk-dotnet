using System.Collections.Generic;

namespace ScalablePressAPI.Models
{
    public class ProductInfo : Product
    {
        public string comments { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public Properties properties { get; set; }
        public IEnumerable<Color> colors { get; set; }
        public IEnumerable<Additionalimage> additionalImages { get; set; }
        public bool available { get; set; }
        public string availabilityUrl { get; set; }

        //public string productId { get; set; }
    }
}
