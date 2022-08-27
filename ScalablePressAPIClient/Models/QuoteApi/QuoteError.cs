namespace ScalablePress.API.Models.QuoteApi
{
    public class QuoteError
    {
        /// <summary>
        /// string Identifier for type of error message
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// string Path in quote object causing error
        /// </summary>
        public string path { get; set; }

        /// <summary>
        /// string User-friendly error message
        /// </summary>
        public string message { get; set; }

        public override string ToString() =>
            message ?? base.ToString();
    }
}