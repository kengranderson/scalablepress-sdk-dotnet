using ScalablePress.API.Models.DesignApi;
using ScalablePress.API.Models.MockupApi;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace APIClientTest
{
    [Binding]
    class MockupAPITestsStepDefinitions : StepDefinitionsBase
    {
        DesignRequest design;
        MockupResponse response;

        [Given(@"a design is created from a random image in the images folder")]
        public void GivenADesignIsCreatedFromARandomImageInTheImagesFolder()
        {
            design = CreateDesignFromRandomImageAsync();
        }

        [When(@"the Mockup API is called")]
        public async Task WhenTheMockupAPIIsCalled()
        {
            var mockup = new Mockup
            { 
                design = design,
                product = new MockupProduct
                { 
                    id = AvailableProducts.gildan_cotton_t_shirt,
                    color = "black"
                },
                template = new Template
                { 
                    name = $"Template created at {DateTime.Now}",
                    background = AvailableBackgrounds.brick
                },
                output = new MockupOutput
                { 
                    width = 11,
                    height = 8.5f,
                    padding = 8,
                    format = MockupOutputFormats.jpg
                }
            };
            response = await _apiClient.MockupAPI.CreateMockupAsync(mockup).ConfigureAwait(false);
        }

        [Then(@"the result should be a Url")]
        public void ThenTheResultShouldBeAUrl()
        {
            Assert.NotNull(response);
        }
    }
}
