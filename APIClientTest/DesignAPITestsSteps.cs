using ScalablePress.API.Models.DesignApi;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace APIClientTest
{
    [Binding]
    class DesignAPITestsSteps : StepsBase
    {
        Design design = new Design();

        [Given(@"I have specified the design type as ""(.*)""")]
        public void GivenIHaveSpecifiedTheDesignTypeAs(string designType)
        {
            design.type = Enum.Parse<DesignTypes>(designType);
        }

        [Given(@"named the design ""(.*)""")]
        public void GivenNamedTheDesign(string designName)
        {
            design.name = designName;
        }

        [Given(@"specified the design image as ""(.*)""")]
        public void GivenSpecifiedTheDesignImageAs(string imageFileName)
        {
            design.sides.front = new DesignSide
            { 
                artwork = imageFileName,
                aspect = 1,
                resize = true,
                colors = new string[] { "black" },
                dimensions = Dimension.Width(10),
                position = new Position
                { 
                    horizontal = "C",
                    offset = PositionOffset.FromTop(2)
                }
            };
        }

        [When(@"I call the Design Create API")]
        public void WhenICallTheDesignCreateAPI()
        {
        }

        [Then(@"the result should be a new Design Id")]
        public void ThenTheResultShouldBeANewDesignId()
        {
        }
    }
}
