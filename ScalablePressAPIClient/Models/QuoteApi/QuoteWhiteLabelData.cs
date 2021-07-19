namespace ScalablePress.API.Models.QuoteApi
{
    public class QuoteWhiteLabelData
    {
        public QuoteWhiteLabelData()
        { 
        }

        public QuoteWhiteLabelData(QuoteAddress address)
        {
            whitelabel = address;
        }

        public QuoteAddress whitelabel { get; set; }
    }
}
