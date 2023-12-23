﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace APIClientTest.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class DesignAPITestsFeature : object, Xunit.IClassFixture<DesignAPITestsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "DesignAPITests.feature"
#line hidden
        
        public DesignAPITestsFeature(DesignAPITestsFeature.FixtureData fixtureData, APIClientTest_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "DesignAPITests", "\tIn order to test the Design API\r\n\twe call these methods", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Create Design")]
        [Xunit.TraitAttribute("FeatureTitle", "DesignAPITests")]
        [Xunit.TraitAttribute("Description", "Create Design")]
        [Xunit.TraitAttribute("Category", "create")]
        public void CreateDesign()
        {
            string[] tagsOfScenario = new string[] {
                    "create"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Design", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "name",
                            "type",
                            "front_artwork",
                            "front_dimensions_height",
                            "front_dimensions_width",
                            "front_position_horizontal",
                            "front_position_offset_bottom",
                            "front_position_offset_front",
                            "back_artwork",
                            "back_dimensions_height",
                            "back_dimensions_width",
                            "back_position_horizontal",
                            "back_position_offset_bottom",
                            "back_position_offset_top",
                            "left_artwork",
                            "left_dimensions_height",
                            "left_dimensions_width",
                            "left_position_horizontal",
                            "left_position_offset_bottom",
                            "left_position_offset_top",
                            "right_artwork",
                            "right_dimensions_height",
                            "right_dimensions_width",
                            "right_position_horizontal",
                            "right_position_offset_bottom",
                            "right_position_offset_top"});
#line 7
 testRunner.Given("the table of data", ((string)(null)), table1, "Given ");
#line hidden
#line 10
 testRunner.When("I call the Design Create API", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 11
 testRunner.Then("the result should be a new Design Id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Create Design, Get Quote, Place Order")]
        [Xunit.TraitAttribute("FeatureTitle", "DesignAPITests")]
        [Xunit.TraitAttribute("Description", "Create Design, Get Quote, Place Order")]
        [Xunit.TraitAttribute("Category", "create-to-order")]
        public void CreateDesignGetQuotePlaceOrder()
        {
            string[] tagsOfScenario = new string[] {
                    "create-to-order"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Design, Get Quote, Place Order", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 14
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 15
 testRunner.Given("design is created from a random image in the images folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 16
 testRunner.And("a Quote is generated from the Design Id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 17
 testRunner.When("an Order is placed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 18
 testRunner.Then("we should have an Order Id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Pull Designs from ScalablePress")]
        [Xunit.TraitAttribute("FeatureTitle", "DesignAPITests")]
        [Xunit.TraitAttribute("Description", "Pull Designs from ScalablePress")]
        [Xunit.TraitAttribute("Category", "pull-designs")]
        [Xunit.InlineDataAttribute("649e4d95162dcd09050e6142", new string[0])]
        [Xunit.InlineDataAttribute("649e4c6a8c04d642f9c2a2b1", new string[0])]
        [Xunit.InlineDataAttribute("649cc0cd15d4964279f2af5e", new string[0])]
        [Xunit.InlineDataAttribute("649a563f1cae4274a66f267e", new string[0])]
        [Xunit.InlineDataAttribute("6493b92f5d15831bf83aaf1d", new string[0])]
        [Xunit.InlineDataAttribute("6493a9e04237095d485e13a2", new string[0])]
        [Xunit.InlineDataAttribute("6473c45c1c0a1b6f01be7113", new string[0])]
        [Xunit.InlineDataAttribute("6473c451352230775ac9f7bd", new string[0])]
        [Xunit.InlineDataAttribute("63fa3a25083a60397d6db29d", new string[0])]
        [Xunit.InlineDataAttribute("63f03e21f1b7c639979647c0", new string[0])]
        [Xunit.InlineDataAttribute("63ab961a1039c4465ebc85ea", new string[0])]
        [Xunit.InlineDataAttribute("63ab92d0b6fa0077469f5b81", new string[0])]
        [Xunit.InlineDataAttribute("63ab924ef09d447668ee5103", new string[0])]
        [Xunit.InlineDataAttribute("639bd6b132248e223d7a3eff", new string[0])]
        [Xunit.InlineDataAttribute("6306ab01403284422b1959ef", new string[0])]
        [Xunit.InlineDataAttribute("6306a84cfc24776e9f4d9a5b", new string[0])]
        [Xunit.InlineDataAttribute("6306a186403284422b1957c4", new string[0])]
        [Xunit.InlineDataAttribute("63068ae3cb5676790b1507d5", new string[0])]
        [Xunit.InlineDataAttribute("61ff32a210583347a0137d97", new string[0])]
        [Xunit.InlineDataAttribute("61ea7bf5626a773f8fd1a0b0", new string[0])]
        [Xunit.InlineDataAttribute("61ea7bf3452baa69c2b86619", new string[0])]
        [Xunit.InlineDataAttribute("61ea7bf091bc461b46c30a2e", new string[0])]
        [Xunit.InlineDataAttribute("61ea7bef66681b726e38114c", new string[0])]
        [Xunit.InlineDataAttribute("61ea7beddc391206b64caa52", new string[0])]
        [Xunit.InlineDataAttribute("61ea7beb452baa69c2b86618", new string[0])]
        [Xunit.InlineDataAttribute("61ea7be928a70337dcc3e9a3", new string[0])]
        [Xunit.InlineDataAttribute("61ea7be859107869cf0353b8", new string[0])]
        [Xunit.InlineDataAttribute("61ea7be68f40f71b392d0602", new string[0])]
        [Xunit.InlineDataAttribute("61ea7be4626a773f8fd1a0af", new string[0])]
        [Xunit.InlineDataAttribute("61ea7be228a70337dcc3e9a2", new string[0])]
        [Xunit.InlineDataAttribute("61ea7be0452baa69c2b86617", new string[0])]
        [Xunit.InlineDataAttribute("61ea7bde626a773f8fd1a0ae", new string[0])]
        [Xunit.InlineDataAttribute("61ea7bdb8f40f71b392d0601", new string[0])]
        [Xunit.InlineDataAttribute("61ea7bd931d76c69ce6c345c", new string[0])]
        [Xunit.InlineDataAttribute("61ea7bca28a70337dcc3e9a1", new string[0])]
        [Xunit.InlineDataAttribute("61df2e2325b43e45469baf2b", new string[0])]
        [Xunit.InlineDataAttribute("613d02838e3c2946aee47484", new string[0])]
        [Xunit.InlineDataAttribute("61380d7b2c9c320597720d14", new string[0])]
        [Xunit.InlineDataAttribute("61380be2b5416a46ba5a56eb", new string[0])]
        [Xunit.InlineDataAttribute("61380b8842eeb546b4918e5b", new string[0])]
        [Xunit.InlineDataAttribute("61380b1e8e3c2946aee3013a", new string[0])]
        [Xunit.InlineDataAttribute("6137fa1242eeb546b49189d3", new string[0])]
        [Xunit.InlineDataAttribute("6123212e4bcc0c4fb37c45b9", new string[0])]
        [Xunit.InlineDataAttribute("6123212b3282717de7a53347", new string[0])]
        [Xunit.InlineDataAttribute("61228be41e971c4fa1768198", new string[0])]
        [Xunit.InlineDataAttribute("611f191146cbf22c39671391", new string[0])]
        [Xunit.InlineDataAttribute("611f190e067e22268ff2441c", new string[0])]
        [Xunit.InlineDataAttribute("611f190b819f294fad237ae0", new string[0])]
        [Xunit.InlineDataAttribute("611f190897a3362c2f5f2243", new string[0])]
        [Xunit.InlineDataAttribute("611f1906731e042a41bfe5e1", new string[0])]
        [Xunit.InlineDataAttribute("611f1903819f294fad237ade", new string[0])]
        [Xunit.InlineDataAttribute("611f1900903c816db29fb1e6", new string[0])]
        [Xunit.InlineDataAttribute("611f18fe2f2dfc02091fb225", new string[0])]
        [Xunit.InlineDataAttribute("611f18fb1e971c4fa175baac", new string[0])]
        [Xunit.InlineDataAttribute("611f18f897a3362c2f5f223d", new string[0])]
        [Xunit.InlineDataAttribute("611f18f52f2dfc02091fb224", new string[0])]
        [Xunit.InlineDataAttribute("611f18f31e971c4fa175baab", new string[0])]
        [Xunit.InlineDataAttribute("611f18eff411f86da544c887", new string[0])]
        [Xunit.InlineDataAttribute("611f18e9067e22268ff24416", new string[0])]
        [Xunit.InlineDataAttribute("611f18e63282717de7a4406e", new string[0])]
        [Xunit.InlineDataAttribute("611f18e3067e22268ff24415", new string[0])]
        [Xunit.InlineDataAttribute("611f18def411f86da544c886", new string[0])]
        [Xunit.InlineDataAttribute("611f18db1e971c4fa175baaa", new string[0])]
        [Xunit.InlineDataAttribute("611f18d52f2dfc02091fb223", new string[0])]
        [Xunit.InlineDataAttribute("611f18d2819f294fad237adb", new string[0])]
        [Xunit.InlineDataAttribute("611f18cf2f2dfc02091fb222", new string[0])]
        [Xunit.InlineDataAttribute("611f18ccb23a172fe8f86bab", new string[0])]
        [Xunit.InlineDataAttribute("611f18c91e971c4fa175baa9", new string[0])]
        [Xunit.InlineDataAttribute("611f18c62f27820215ca30f1", new string[0])]
        [Xunit.InlineDataAttribute("611f18c3b23a172fe8f86baa", new string[0])]
        [Xunit.InlineDataAttribute("611f18c04bcc0c4fb37b5354", new string[0])]
        [Xunit.InlineDataAttribute("611f18bd55d0fd020258813a", new string[0])]
        [Xunit.InlineDataAttribute("611f18b9903c816db29fb1cd", new string[0])]
        [Xunit.InlineDataAttribute("611f18b62f2dfc02091fb221", new string[0])]
        [Xunit.InlineDataAttribute("611f18b1731e042a41bfe5c7", new string[0])]
        [Xunit.InlineDataAttribute("611f1880731e042a41bfe5c3", new string[0])]
        [Xunit.InlineDataAttribute("611f187c903c816db29fb1c2", new string[0])]
        [Xunit.InlineDataAttribute("6123414bb23a172fe8f96e01", new string[0])]
        [Xunit.InlineDataAttribute("612342cd1e971c4fa176ba93", new string[0])]
        public void PullDesignsFromScalablePress(string designId, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "pull-designs"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("designId", designId);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Pull Designs from ScalablePress", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 21
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 22
testRunner.Given(string.Format("a ScalablePress Design with Id \"{0}\"", designId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 23
testRunner.When("I retrieve the Design corresponding to the Id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 24
testRunner.Then("a DesignTemplate record will be created if necessary, and the data from ScalableP" +
                        "ress will be written to the DesignTemplate record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                DesignAPITestsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                DesignAPITestsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
