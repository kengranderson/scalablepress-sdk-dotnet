namespace ScalablePress.API.Models.DesignApi
{
    /// <summary>
    /// For screenprint/DTG/poster orders, height OR width is required. 
    /// The print will automatically be scaled to keep aspect ratio. 
    /// For poster orders, height OR width must either be set to 17 or 24.
    /// </summary>
    public class Dimension
    {
        /// <summary>
        /// Screenprint/DTG/poster only, width in inches of the print on the garment, 
        /// or the width of the poster, specify this OR the height of the print
        /// </summary>
        public float? width { get; set; }

        /// <summary>
        /// Screenprint/DTG/poster only, height in inches of the print on the garment, 
        /// or the height of the poster, specify this OR the width of the print
        /// </summary>
        public float? height { get; set; }

        public static Dimension Width(float width) =>
            new Dimension
            {
                width = width
            };

        public static Dimension Height(float height) =>
            new Dimension
            {
                height = height
            };
    }
}
