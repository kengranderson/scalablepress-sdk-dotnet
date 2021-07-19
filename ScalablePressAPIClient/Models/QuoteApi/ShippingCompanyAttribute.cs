using System;

namespace ScalablePress.API.Models.QuoteApi
{
    internal class ShippingCompanyAttribute : Attribute
    {
        public ShippingCompanyAttribute(string company)
        {
            Company = company;
        }

        public string Company { get; }
    }
}
