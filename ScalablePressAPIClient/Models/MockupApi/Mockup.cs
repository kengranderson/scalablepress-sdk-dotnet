using ScalablePress.API.Models.DesignApi;

namespace ScalablePress.API.Models.MockupApi
{
    public class Mockup
    {
        /// <summary>
        /// Template object
        /// </summary>
        public Template template { get; set; }

        /// <summary>
        /// Mockup product object
        /// </summary>
        public MockupProduct product { get; set; }

        /// <summary>
        /// Design object
        /// </summary>
        public DesignRequest design { get; set; }

        /// <summary>
        /// Mockup output object
        /// </summary>
        public MockupOutput output { get; set; }	
    }
}
