using ScalablePress.API.Converters;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace ScalablePress.API.Models.QuoteApi
{
    [JsonConverter(typeof(EnumValueAttributeConverter))]
    public enum QuoteShippingOptions
    {
        [Description("First Class")]
        [ShippingCompany("USPS")]
        [EnumValue("US-FC")]
        US_FC,

        [Description("Parcel Post")]
        [ShippingCompany("USPS")]
        [EnumValue("US-PP")]
        US_PP,

        [Description("Parcel Select")]
        [ShippingCompany("USPS")]
        [EnumValue("US-PS")]
        US_PS,

        [Description("Priority Mail")]
        [ShippingCompany("USPS")]
        [EnumValue("US-PM")]
        US_PM,

        [Description("First Class International")]
        [ShippingCompany("USPS")]
        [EnumValue("US-FCI")]
        US_FCI,

        [Description("Priority Mail International")]
        [ShippingCompany("USPS")]
        [EnumValue("US-PMI")]
        US_PMI,

        [Description("Next Day Air")]
        [ShippingCompany("UPS")]
        [EnumValue("UPS-1DA")]
        UPS_1DA,

        [Description("Next Day Air Saver")]
        [ShippingCompany("UPS")]
        [EnumValue("UPS-1DP")]
        UPS_1DP,

        [Description("2 Day")]
        [ShippingCompany("UPS")]
        [EnumValue("UPS-2DA")]
        UPS_2DA,

        [Description("3 Day Select")]
        [ShippingCompany("UPS")]
        [EnumValue("UPS-3DS")]
        UPS_3DS,

        [Description("Ground")]
        [ShippingCompany("UPS")]
        [EnumValue("UPS-GND")]
        UPS_GND,

        [Description("First Overnight")]
        [ShippingCompany("FEDEX")]
        [EnumValue("FDX-FO")]
        FDX_FO,

        [Description("Priority Overnight")]
        [ShippingCompany("FEDEX")]
        [EnumValue("FDX-PO")]
        FDX_PO,

        [Description("Standard Overnight")]
        [ShippingCompany("FEDEX")]
        [EnumValue("FDX-SO")]
        FDX_SO,

        [Description("2 Day AM")]
        [ShippingCompany("FEDEX")]
        [EnumValue("FDX-2DA")]
        FDX_2DA,

        [Description("2 Day")]
        [ShippingCompany("FEDEX")]
        [EnumValue("FDX-2D")]
        FDX_2D,

        [Description("Express Saver")]
        [ShippingCompany("FEDEX")]
        [EnumValue("FDX-ES")]
        FDX_ES,

        [Description("Ground")]
        [ShippingCompany("FEDEX")]
        [EnumValue("FDX-GND")]
        FDX_GND,

        [Description("Smart Mail (SM) Parcels standard or SM Parcels plus standard")]
        [ShippingCompany("DHL")]
        [EnumValue("DHL-SM")]
        DHL_SM,

        [Description("Smart Mail (SM) Parcels expedited or SM Parcels plus expedited")]
        [ShippingCompany("DHL")]
        [EnumValue("DHL-SME")]
        DHL_SME,

        [Description("GM Packet Plus or GM Parcel Priority")]
        [ShippingCompany("DHL")]
        [EnumValue("DHL-GM")]
        DHL_GM,

        [Description("Global Mail (GM) Packet Priority PKY or GM Packet Priority PLY")]
        [ShippingCompany("DHL")]
        [EnumValue("DHL-GME")]
        DHL_GME
    }
}
