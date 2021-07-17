using System;
using System.Collections.Generic;

namespace ScalablePress.API.Models.DesignApi
{
    public class DesignResponse
    {
        public string designId { get; set; }

        /// <summary>
        /// the type of product this design is for. screenprint, dtg, case, mug, or poster
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// Time when design was created
        /// </summary>
        public DateTime createdAt { get; set; }

        /// <summary>
        /// Design validation object
        /// </summary>
        public DesignValidation validation { get; set; }

        /// <summary>
        /// Array of customization objects
        /// </summary>
        public IEnumerable<Customization> customization { get; set; }

        /// <summary>
        /// Design sides object
        /// </summary>
        public DesignSides sides { get; set; }

        /// <summary>
        /// test or live
        /// </summary>
        public string mode { get; set; }

        public string source { get; set; }

        public string name { get; set; }
        
        public bool conversion { get; set; }
        
        public bool review { get; set; }
    }
}
