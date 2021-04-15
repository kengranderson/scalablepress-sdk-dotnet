using System.Collections.Generic;

namespace ScalablePress.API.Models.DesignApi
{
    public class DesignCustomization
    {
        /// <summary>
        /// Optional list of each desired customization applied to the design
        /// </summary>
        public IEnumerable<Customization> customization { get; set; }
    }
}
