using ScalablePress.API.Models.DesignApi;
using System;
using System.IO;
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

        Design design = new Design();
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
            designResponse = await apiClient.DesignAPI.PostDesignAsync(design).ConfigureAwait(false);
        }

        [Then(@"the result should be a new Design Id")]
        public void ThenTheResultShouldBeANewDesignId()
        {
            Assert.True(apiClient.DesignAPI.ApiCallSuccess);
        }

        #endregion

        #region Create to Order Scenario

        string createToOrderDesignId;
        string createToOrderQuoteId;
        string createToOrderOrderId;

        [Given(@"design is created from a random image in the images folder")]
        public async Task GivenDesignIsCreatedFromARandomImageInTheImagesFolder()
        {
            var rand = new Random();
            var files = Directory.GetFiles("C:\\BFU\\350years\\pngs", "*.png");
            var randomImageFileName = files[rand.Next(files.Length)];
            var design = new Design
            {
                name = $"Design created on {DateTime.Now}",
                type = DesignTypes.dtg,
                sides = new DesignSides
                {
                    front = new DesignSide
                    {
                        artwork = randomImageFileName,
                        aspect = 1,
                        resize = true,
                        dimensions = Dimension.Width(11),
                        position = new Position
                        {
                            horizontal = "C",
                            offset = PositionOffset.FromTop(2.5f)
                        }
                    }
                }
            };
            var designResponse = await apiClient.DesignAPI.PostDesignAsync(design).ConfigureAwait(false);
            createToOrderDesignId = designResponse.designId;
        }


        [Given(@"a Quote is generated from the Design Id")]
        public void GivenAQuoteIsGeneratedFromTheDesignId()
        {
        }

        [When(@"an Order is placed")]
        public void WhenAnOrderIsPlaced()
        {
        }

        [Then(@"we should have an Order Id")]
        public void ThenWeShouldHaveAnOrderId()
        {
        }

        #endregion
    }
}
