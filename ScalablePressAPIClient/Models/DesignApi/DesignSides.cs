namespace ScalablePress.API.Models.DesignApi
{
    /// <summary>
    /// For case, mug and poster printing, only the front side is used.
    /// </summary>
    /// <remarks>
    /// At least one side is required for the design
    /// </remarks>
    public class DesignSides
    {
        /// <summary>
        /// Design side object
        /// </summary>
        public DesignSide front { get; set; }

        /// <summary>
        /// Design side object
        /// </summary>
        public DesignSide back { get; set; }

        /// <summary>
        /// Design side object
        /// </summary>
        public DesignSide left { get; set; }

        /// <summary>
        /// Design side object
        /// </summary>
        public DesignSide right { get; set; }
    }
}
