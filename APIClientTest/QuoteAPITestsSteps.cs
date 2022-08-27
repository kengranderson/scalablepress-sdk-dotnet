using ScalablePress.API.Models;
using ScalablePress.API.Models.QuoteApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace APIClientTest
{
    [Binding]
    class QuoteAPITestsSteps : StepsBase
    {
        #region Fields

        IEnumerable<Product> productCatalog;
        IEnumerable<Product> invalidProducts;
        IEnumerable<ProductSizes> productSizes;
        IEnumerable<ProductSizes> invalidSizes;
        IEnumerable<Colors> productColors;
        IEnumerable<Colors> invalidColors;
        IEnumerable<QuoteAddress> addressBook;
        IEnumerable<QuoteAddress> invalidAddresses;
        IEnumerable<QuoteAddress> companyAddresses;

        IEnumerable<Product> selectedProducts;
        int quantityEach;
        IEnumerable<ProductSizes> selectedSizes;
        IEnumerable<Colors> selectedColors;
        IEnumerable<QuoteAddress> selectedCustomerAddresses;
        IEnumerable<QuoteAddress> selectedCompanyAddresses;

        StandardQuoteRequest standardQuote;
        BulkQuoteRequest bulkQuote;
        QuoteResponse response;

        #endregion

        #region Background

        [Given(@"the Swag Catalog contains these products")]
        public void GivenTheSwagCatalogContainsTheseProducts(Table table)
        {
            productCatalog = table.CreateSet<Product>();
        }

        [Given(@"invalid products are listed here")]
        public void GivenInvalidProductsAreListedHere(Table table)
        {
            invalidProducts = table.CreateSet<Product>();
        }

        [Given(@"products are available in these sizes")]
        public void GivenProductsAreAvailableInTheseSizes(Table table)
        {
            productSizes = table.CreateSet<ProductSizes>();
        }

        [Given(@"invalid product sizes are listed here")]
        public void GivenInvalidProductSizesAreListedHere(Table table)
        {
            invalidSizes = table.CreateSet<ProductSizes>();
        }

        [Given(@"products are available in these colors")]
        public void GivenProductsAreAvailableInTheseColors(Table table)
        {
            productColors = table.CreateSet<Colors>();
        }

        [Given(@"invalid product colors are listed here")]
        public void GivenInvalidProductColorsAreListedHere(Table table)
        {
            invalidColors = table.CreateSet<Colors>();
        }

        [Given(@"our address book contains these addresses")]
        public void GivenOurAddressBookContainsTheseAddresses(Table table)
        {
            addressBook = table.CreateSet<QuoteAddress>();
        }

        [Given(@"the custom label from address is")]
        public void GivenTheCustomLabelFromAddressIs(Table table)
        {
            companyAddresses = table.CreateSet<QuoteAddress>();
        }

        [Given(@"the invalid address book contains these addresses")]
        public void GivenTheInvalidAddressBookContainsTheseAddresses(Table table)
        {
            invalidAddresses = table.CreateSet<QuoteAddress>();
        }

        #endregion

        #region Selections

        [Given(@"the first (.*) products are selected")]
        public void GivenTheFirstProductsAreSelected(int count)
        {
            selectedProducts = productCatalog.Take(count).ToList();
        }

        [Given(@"the first (.*) invalid products get selected")]
        public void GivenTheFirstInvalidProductsGetSelected(int count)
        {
            selectedProducts = productCatalog.Take(count).ToList();
        }

        [Given(@"the quantity ordered is (.*) each")]
        public void GivenTheQuantityOrderedIsEach(int count)
        {
            quantityEach = count;
        }

        [Given(@"the first (.*) sizes are selected")]
        public void GivenTheFirstSizesAreSelected(int count)
        {
            selectedSizes = productSizes.Take(count).ToList();
        }

        [Given(@"the first (.*) colors are selected")]
        public void GivenTheFirstColorsAreSelected(int count)
        {
            selectedColors = productColors.Take(count).ToList();
        }

        [Given(@"the first (.*) addresses are selected")]
        public void GivenTheFirstAddressesAreSelected(int count)
        {
            selectedCustomerAddresses = addressBook.Take(count).ToList();
        }

        [Given(@"the first (.*) custom addresses is selected")]
        public void GivenTheFirstCustomAddressesIsSelected(int count)
        {
            selectedCompanyAddresses = companyAddresses.Take(count).ToList();
        }

        [Given(@"the first (.*) invalid products are selected")]
        public void GivenTheFirstInvalidProductsAreSelected(int count)
        {
            selectedProducts = invalidProducts.Take(count).ToList();
        }

        [Given(@"the first (.*) invalid colors are selected")]
        public void GivenTheFirstInvalidColorsAreSelected(int count)
        {
            selectedColors = invalidColors.Take(count).ToList();
        }

        [Given(@"the first (.*) invalid sizes are selected")]
        public void GivenTheFirstInvalidSizesAreSelected(int count)
        {
            selectedSizes = invalidSizes.Take(count).ToList();
        }

        [Given(@"the first (.*) invalid addresses are selected")]
        public void GivenTheFirstInvalidAddressesAreSelected(int count)
        {
            selectedCustomerAddresses = invalidAddresses.Take(count).ToList();
        }

        #endregion

        #region Generate Quote

        [When(@"a Standard Quote is generated with this data")]
        public void WhenAStandardQuoteIsGeneratedWithThisData()
        {
            standardQuote = CreateQuotes(1).Single();
        }

        [When(@"a Bulk Quote is generated with this data")]
        public void WhenABulkQuoteIsGeneratedWithThisData()
        {
            bulkQuote = new BulkQuoteRequest
            {
                name = $"Bulk Quote created at {DateTime.Now}",
                items = CreateQuotes(selectedProducts.Count()),
                data = new BulkQuoteFeatures
                { 
                    breakdown = true
                }
            };
        }

        IEnumerable<StandardQuoteRequest> CreateQuotes(int count)
        {
            static void MoveNext<T>(IEnumerator<T> iterator)
            {
                if (!iterator.MoveNext())
                {
                    iterator.Reset();
                    iterator.MoveNext();
                }
            }

            var addresses = selectedCustomerAddresses.GetEnumerator();
            var products = selectedProducts.GetEnumerator();
            var colors = selectedColors.GetEnumerator();
            var sizes = selectedSizes.GetEnumerator();

            var quotes = Enumerable.Range(0, count).Select(i =>
            {
                MoveNext(addresses);
                MoveNext(products);
                MoveNext(colors);
                MoveNext(sizes);

                var _standardQuote = new StandardQuoteRequest
                {
                    address = addresses.Current,
                    designId = products.Current.designId,
                    name = products.Current.title,
                    products = new QuoteProduct[] { products.Current.ToQuoteProduct(colors.Current.color, sizes.Current.size, quantityEach) },
                    type = PrintingTypes.dtg,
                    data = selectedCompanyAddresses != null ?
                        new QuoteWhiteLabelData 
                        { 
                            whitelabel = selectedCompanyAddresses.FirstOrDefault()
                        } : null
                };

                return _standardQuote;
            });

            return quotes;
        }

        #endregion

        #region Process Quote Response

        [Then(@"the result should contain an Order Token")]
        public async Task ThenTheResultShouldContainAnOrderToken()
        {
            response = await GetQuoteResponse(standardQuote, bulkQuote).ConfigureAwait(false);
            Assert.NotNull(response.orderToken);
        }

        [Then(@"the result should contain an Error Response")]
        public async Task ThenTheResultShouldContainAnErrorResponse()
        {
            response = await GetQuoteResponse(standardQuote, bulkQuote).ConfigureAwait(false);
            Assert.NotNull(response.issues);
        }

        #endregion
    }
}
