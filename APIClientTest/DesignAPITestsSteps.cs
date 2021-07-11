using ScalablePress.API;
using ScalablePress.API.Models.DesignApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace APIClientTest
{
    [Binding]
    class DesignAPITestsSteps : StepsBase
    {
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
                artwork = row.sides_front_artwork != null ? File.ReadAllBytes(row.sides_front_artwork) : null,
                proof = row.sides_front_proof != null ? File.ReadAllBytes(row.sides_front_proof) : null,
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
    }
}
