using ScalablePress.API.Models;
using ScalablePress.API.Models.OrderApi;
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
    class OrderAPITestsSteps : StepsBase
    {
        #region Fields

        IEnumerable<Product> productCatalog;
        IEnumerable<ProductSizes> productSizes;
        IEnumerable<Colors> productColors;
        IEnumerable<QuoteAddress> addressBook;
        IEnumerable<QuoteAddress> companyAddresses;

        IEnumerable<Product> selectedProducts;
        int quantityEach;
        IEnumerable<ProductSizes> selectedSizes;
        IEnumerable<Colors> selectedColors;
        IEnumerable<QuoteAddress> selectedCustomerAddresses;
        IEnumerable<QuoteAddress> selectedCompanyAddresses;

        StandardQuoteRequest standardQuote;
        BulkQuoteRequest bulkQuote;
        QuoteResponse quoteResponse;
        Order order;

        #endregion

        #region Background

        [Given(@"the Catalog contains these products")]
        public void GivenTheCatalogContainsTheseProducts(Table table)
        {
            productCatalog = table.CreateSet<Product>();
        }

        [Given(@"swag products are available in these sizes")]
        public void GivenSwagProductsAreAvailableInTheseSizes(Table table)
        {
            productSizes = table.CreateSet<ProductSizes>();
        }

        [Given(@"swag products are available in these colors")]
        public void GivenSwagProductsAreAvailableInTheseColors(Table table)
        {
            productColors = table.CreateSet<Colors>();
        }

        [Given(@"the address book contains these addresses")]
        public void GivenTheAddressBookContainsTheseAddresses(Table table)
        {
            addressBook = table.CreateSet<QuoteAddress>();
        }

        [Given(@"custom label from address is")]
        public void GivenCustomLabelFromAddressIs(Table table)
        {
            companyAddresses = table.CreateSet<QuoteAddress>();
        }

        #endregion

        #region Selections

        [Given(@"the swag quantity ordered is (.*) each")]
        public void GivenTheSwagQuantityOrderedIsEach(int count)
        {
            quantityEach = count;
        }

        //[Given(@"the first (.*) custom addresses is selected")]
        //public void GivenTheFirstCustomAddressesIsSelected(int count)
        //{
        //    selectedCompanyAddresses = companyAddresses.Take(count).ToList();
        //}
        [Given(@"(.*) swag products are selected")]
        public void GivenSwagProductsAreSelected(int count)
        {
            selectedProducts = productCatalog.Take(count).ToList();
        }

        [Given(@"(.*) swag sizes are selected")]
        public void GivenSwagSizesAreSelected(int count)
        {
            selectedSizes = productSizes.Take(count).ToList();
        }

        [Given(@"(.*) swag colors are selected")]
        public void GivenSwagColorsAreSelected(int count)
        {
            selectedColors = productColors.Take(count).ToList();
        }

        [Given(@"(.*) swag addresses are selected")]
        public void GivenSwagAddressesAreSelected(int count)
        {
            selectedCustomerAddresses = addressBook.Take(count).ToList();
        }

        #endregion

        #region Generate Quote

        [When(@"a Standard Quote is generated with this swag data")]
        public void WhenAStandardQuoteIsGeneratedWithThisSwagData()
        {
            standardQuote = CreateQuotes(1).Single();
        }

        [When(@"a Bulk Quote is generated with this swag data")]
        public void WhenABulkQuoteIsGeneratedWithThisSwagData()
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

        [Then(@"the result should contain a new Order Token")]
        public async Task ThenTheResultShouldContainANewOrderToken()
        {
            quoteResponse = await GetQuoteResponse(standardQuote, bulkQuote).ConfigureAwait(false);
            Assert.NotNull(quoteResponse.orderToken);
        }

        #endregion

        #region Place Order

        [Then(@"when the Order Token is used to place an Order")]
        public async Task ThenWhenTheOrderTokenIsUsedToPlaceAnOrder()
        {
            order = await apiClient.OrderAPI.PlaceOrderAsync(quoteResponse.orderToken).ConfigureAwait(false);
        }

        [Then(@"and Order Id should be returned")]
        public void ThenAndOrderIdShouldBeReturned()
        {
            Assert.NotNull(order.orderId);
        }

        #endregion
    }
}
