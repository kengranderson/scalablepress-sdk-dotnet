namespace ScalablePress.API.Models.QuoteApi
{
    public class QuoteAddress
    {
        /// <summary>
        /// Name of customer receiving the product
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Optional company associated with the customer
        /// </summary>
        public string company { get; set; }

        /// <summary>
        /// Address line 1 of customer
        /// </summary>
        public string address1 { get; set; }

        /// <summary>
        /// Optional address line 2 of customer
        /// </summary>
        public string address2 { get; set; }

        /// <summary>
        /// City of customer
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// State or province where customer resides
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// Zip code or postal code of customer
        /// </summary>
        public string zip { get; set; }

        /// <summary>
        /// ISO3166 country code, defaults to US
        /// </summary>
        public string country { get; set; }

        public override string ToString() =>
            $"{name} {company} {address1} {address2} {city}, {state} {zip} {country}";
    }
}
