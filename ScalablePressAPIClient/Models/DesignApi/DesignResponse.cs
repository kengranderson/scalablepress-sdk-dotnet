using System;
using System.Collections.Generic;

namespace ScalablePress.API.Models.DesignApi
{
    public class DesignResponse
    {
        public string source { get; set; }
        public string hash { get; set; }

        /// <summary>
        /// test or live
        /// </summary>
        public ApiModes mode { get; set; }

        /// <summary>
        /// the type of product this design is for. screenprint, dtg, case, mug, or poster
        /// </summary>
        public PrintingTypes type { get; set; }

        public string name { get; set; }

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

        public bool vectorization { get; set; }
        public bool conversion { get; set; }       
        public bool review { get; set; }

        /// <summary>
        /// Design sides object
        /// </summary>
        public DesignSides sides { get; set; }

        public string designId { get; set; }
        public override string ToString() => designId ?? base.ToString();
    }
}
