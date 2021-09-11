using ScalablePress.API.Models;
using ScalablePress.API.Models.DesignApi;
using ScalablePress.API.Models.QuoteApi;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace APIClientTest
{
    [Binding]
    class DesignAPITestsSteps : StepsBase
    {

        #region Create Design Scenario

        DesignRequest design = new DesignRequest();
        DesignResponse designResponse;

        [Given(@"the table of data")]
        public void GivenTheTableOfData(Table table)
        {
            var row = table.CreateInstance<DesignTableRow>();

            design.name = row.name;
            design.type = Enum.Parse<DesignTypes>(row.type);
            design.sides.front = new DesignSide
            {
                artwork = row.sides_front_artwork,
                proof = row.sides_front_proof,
                aspect = 1,
                resize = true,
                dimensions = Dimension.Width(row.sides_front_dimensions_width),
                position = new Position
                {
                    horizontal = row.sides_front_position_horizontal,
                    offset = PositionOffset.FromTop(row.sides_front_position_offset_top)
                }
            };
        }

        [When(@"I call the Design Create API")]
        public async Task WhenICallTheDesignCreateAPI()
        {
            designResponse = await apiClient.DesignAPI.CreateDesignAsync(design).ConfigureAwait(false);
        }

        [Then(@"the result should be a new Design Id")]
        public void ThenTheResultShouldBeANewDesignId()
        {
            Assert.True(apiClient.DesignAPI.ApiCallSuccess);
        }

        #endregion

        #region Create to Order Scenario

        string createToOrderDesignId;
        string createToOrderOrderToken;
        string createToOrderQuoteId;

        [Given(@"design is created from a random image in the images folder")]
        public async Task GivenDesignIsCreatedFromARandomImageInTheImagesFolder()
        {
            //var rand = new Random();
            //var files = Directory.GetFiles("C:\\BFU\\350years\\pngs", "*.png");
            //var randomImageFileName = files[rand.Next(files.Length)];
            //var design = new Design
            //{
            //    name = $"Design created on {DateTime.Now}",
            //    type = DesignTypes.dtg,
            //    sides = new DesignSides
            //    {
            //        front = new DesignSide
            //        {
            //            artwork = randomImageFileName,
            //            aspect = 1,
            //            resize = true,
            //            dimensions = Dimension.Width(11),
            //            position = new Position
            //            {
            //                horizontal = "C",
            //                offset = PositionOffset.FromTop(2.5f)
            //            }
            //        }
            //    }
            //};
            //var designResponse = await apiClient.DesignAPI.PostDesignAsync(design).ConfigureAwait(false);
            createToOrderDesignId = await Task.FromResult("60f34b7c55323a07cd70cb2e").ConfigureAwait(false); // designResponse.designId;
        }


        [Given(@"a Quote is generated from the Design Id")]
        public async Task GivenAQuoteIsGeneratedFromTheDesignId()
        {
            var address = new QuoteAddress
            { 
                name = "Ken Granderson",
                company = "Blackfacts",
                address1 = "317 Hancock St.",
                address2 = "#2",
                city = "Brooklyn",
                state = "NY",
                zip = "11216",
                country = "US"
            };

            var quote = new StandardQuoteRequest
            { 
                name = $"Quote generated {DateTime.Now}",
                type = PrintingTypes.dtg,
                designId = createToOrderDesignId,
                products = new QuoteProduct[] 
                { 
                    new QuoteProduct
                    { 
                        id = "gildan-sweatshirt-crew",
                        color = "black",
                        size = Sizes.lrg,
                        quantity = 2
                    }
                },
                address = address,
                features = new QuoteCustomFeatures
                {
                    shipping = QuoteShippingOptions.UPS_GND
                },
                data = new QuoteWhiteLabelData(address)
            };

            var response = await apiClient.QuoteAPI.CreateStandardQuoteAsync(quote).ConfigureAwait(false);
            createToOrderOrderToken = response.orderToken;
        }

        [When(@"an Order is placed")]
        public async Task WhenAnOrderIsPlaced()
        {
            var response = await apiClient.OrderAPI.PlaceOrderAsync(createToOrderOrderToken).ConfigureAwait(false);
            createToOrderQuoteId = response.orderId;
        }

        [Then(@"we should have an Order Id")]
        public void ThenWeShouldHaveAnOrderId()
        {
            Assert.NotNull(createToOrderQuoteId);
        }

        #endregion
    }
}
