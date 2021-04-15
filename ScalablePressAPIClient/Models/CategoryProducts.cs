using System.Collections.Generic;
using System.Linq;

namespace ScalablePress.API.Models
{
    public class CategoryProducts : Category
    {
        public IEnumerable<Product> products { get; set; }
        public override string ToString() => $"{base.ToString()} : ({(products ?? Enumerable.Empty<Product>()).Count()})";
    }
}
