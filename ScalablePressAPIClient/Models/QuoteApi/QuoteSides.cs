namespace ScalablePress.API.Models.QuoteApi
{
    public class QuoteSides
    {
        /// <summary>
        /// DTG: set to any positive number to indicate printing on this side, Screenprint: the number of colors used on this side
        /// </summary>
        public int front { get; set; }

        /// <summary>
        /// Same as front
        /// </summary>
        public int back { get; set; }

        /// <summary>
        /// Same as front
        /// </summary>
        public int right { get; set; }

        /// <summary>
        /// Same as front
        /// </summary>
        public int left { get; set; }
    }
}