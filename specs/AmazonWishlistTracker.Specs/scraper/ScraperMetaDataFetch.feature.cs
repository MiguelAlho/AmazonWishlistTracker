﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.2.1
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18051
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace AmazonWishlistTracker.Specs.Scraper
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.2.1")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("ScraperMetaDataFetch")]
    public partial class ScraperMetaDataFetchFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ScraperMetaDataFetch.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ScraperMetaDataFetch", "In order to setup the scraping processfor my personal wishlist\r\nAs a screen scrap" +
                    "ing component\r\nI want to extract the list of wishlists from a wishlist page", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Prepare for book scraping")]
        [NUnit.Framework.CategoryAttribute("mytag")]
        public virtual void PrepareForBookScraping()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Prepare for book scraping", new string[] {
                        "mytag"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "AmazonTarget",
                        "Email"});
            table1.AddRow(new string[] {
                        "UK",
                        "alho@miguelalho.com"});
#line 8
 testRunner.Given("I have configured my scraper with:", ((string)(null)), table1, "Given ");
#line 11
 testRunner.When("I retrieve the users wishlists", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "wishlistName",
                        "wishlistPageId",
                        "bookCount"});
            table2.AddRow(new string[] {
                        "Business",
                        "13WMOM3XTAK5G",
                        "47"});
            table2.AddRow(new string[] {
                        "Drawing",
                        "2G6OFE9P47AKA",
                        "16"});
            table2.AddRow(new string[] {
                        "Electronics",
                        "1BSEQ7U2E6RBE",
                        "4"});
            table2.AddRow(new string[] {
                        "Engeneering and business",
                        "2OPMME7SI9MPV",
                        "36"});
            table2.AddRow(new string[] {
                        "Fiction",
                        "39ACCHDMKVKJ1",
                        "52"});
            table2.AddRow(new string[] {
                        "Home and stuff",
                        "32BRN6BOWYVID",
                        "11"});
            table2.AddRow(new string[] {
                        "Methodologies",
                        "20E6BOWWE0J4T",
                        "35"});
            table2.AddRow(new string[] {
                        "New Wish List",
                        "2P8W7HDF4M6NR",
                        "0"});
            table2.AddRow(new string[] {
                        "Patterns",
                        "34GLJJOVRPDZU",
                        "16"});
            table2.AddRow(new string[] {
                        "Photography",
                        "2WYRZAFDXJ9C2",
                        "7"});
            table2.AddRow(new string[] {
                        "PRoductivity",
                        "1O0W0NU3ZPF1J",
                        "0"});
            table2.AddRow(new string[] {
                        "programming",
                        "2CCU7K0PHVBZ6",
                        "34"});
            table2.AddRow(new string[] {
                        "Psycology",
                        "22JADHUMCHCOZ",
                        "3"});
            table2.AddRow(new string[] {
                        "Training",
                        "MT9A2WI1FL61",
                        "3"});
            table2.AddRow(new string[] {
                        "Web and UI",
                        "10MTFE33315HU",
                        "29"});
            table2.AddRow(new string[] {
                        "Wish List",
                        "GKBVZ2B8F57P",
                        "0"});
#line 12
 testRunner.Then("the scraper should know that there are the following wishlists:", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get list of books in a specific wishlist")]
        public virtual void GetListOfBooksInASpecificWishlist()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get list of books in a specific wishlist", ((string[])(null)));
#line 31
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "AmazonTarget",
                        "Email"});
            table3.AddRow(new string[] {
                        "UK",
                        "alho@miguelalho.com"});
#line 32
 testRunner.Given("I have configured my scraper with:", ((string)(null)), table3, "Given ");
#line 35
 testRunner.When("I retrieve the book list for the Methodologies wishlist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
 testRunner.Then("the scraper should find 35 books in the book list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "bookId",
                        "bookTitle",
                        "amazonPrice"});
            table4.AddRow(new string[] {
                        "0321534468",
                        "Agile Testing: A Practical Guide for Testers and Agile Teams (Addison-Wesley Sign" +
                            "ature) (Paperback)",
                        "36.99"});
            table4.AddRow(new string[] {
                        "0932633692",
                        "Perfect Software: And Other Illusions About Testing (Paperback)",
                        "18.99"});
            table4.AddRow(new string[] {
                        "0321554132",
                        "Managing Software Debt: Building for Inevitable Change (Agile Software Developmen" +
                            "t) (Hardcover)",
                        ""});
#line 37
 testRunner.And("the scraper should know that there are the following books are in the wishlist\'s " +
                    "list", ((string)(null)), table4, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get the best international offer for a book")]
        public virtual void GetTheBestInternationalOfferForABook()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get the best international offer for a book", ((string[])(null)));
#line 43
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "AmazonTarget",
                        "Email"});
            table5.AddRow(new string[] {
                        "UK",
                        "alho@miguelalho.com"});
#line 44
 testRunner.Given("I have configured my scraper with:", ((string)(null)), table5, "Given ");
#line 47
 testRunner.When("I retrieve the best internationl offer the Agile Testing Book", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "bookId",
                        "price",
                        "seller",
                        "sellerId",
                        "condition"});
            table6.AddRow(new string[] {
                        "0321534468",
                        "21.64",
                        "UKPaperbackshop",
                        "A3A72FJ03Q9CJT",
                        "New"});
#line 48
 testRunner.Then("the scraper should return:", ((string)(null)), table6, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
