using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ScalablePress.API.Models
{
    public class SizeItem
    {
        public SizeItem()
        {
        }

        public SizeItem(Sizes size)
        {
            Value = size;
            Text = size
                .GetType()
                .GetMember(size.ToString())
                .FirstOrDefault()?
                .GetCustomAttribute<DescriptionAttribute>()?.
                Description ?? size.ToString();
        }

        public Sizes Value { get; set; }
        public string Text { get; set; }
    }
}
