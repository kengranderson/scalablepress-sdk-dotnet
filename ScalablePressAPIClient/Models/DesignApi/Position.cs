namespace ScalablePress.API.Models.DesignApi
{
    public class Position
    {
        /// <summary>
        /// Screenprint/DTG only, horizontal position. Artwork requirements
        /// </summary>
        public string horizontal { get; set; }

        /// <summary>
        /// Screenprint/DTG only, position offset object
        /// </summary>
        public PositionOffset offset { get; set; }
    }
}
