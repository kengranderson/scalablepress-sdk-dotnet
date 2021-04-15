using System.Collections.Generic;

namespace ScalablePress.API.Models.DesignApi
{
    public class DesignSide
    {
        /// <summary>
        /// file or URL	Artwork file or absolute URL for this side of the design. Artwork requirements
        /// </summary>
        public string artwork { get; set; }

        /// <summary>
        /// file or URL	Optional proof image file or absolute URL showing position of artwork on the product, 
        /// used by our artists to make sure the print dimensions and position are as intended
        /// </summary>
        public string proof { get; set; }

        /// <summary>
        /// Aspect ratio
        /// </summary>
        public float aspect { get; set; }

        /// <summary>
        /// Boolean checking if design should be resized
        /// </summary>
        public bool resize { get; set; }

        /// <summary>
        /// Screenprint only, list of each named color or PMS color used in design. Artwork requirements
        /// </summary>
        public IEnumerable<string> colors { get; set; }

        /// <summary>
        /// Screenprint/DTG/poster only, dimension object
        /// </summary>
        public Dimension dimensions { get; set; }

        /// <summary>
        /// Screenprint/DTG only, position object
        /// </summary>
        public Position position { get; set; }
    }
}
