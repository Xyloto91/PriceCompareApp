using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompareApp.Core;
using PriceCompareApp.Core.Scrapers;
using Xunit;

namespace PriceCompareApp.Test
{
    public class DekomTests
    {
        [Fact]
        public async void Get_products_data_for_item_codes()
        {
            //Arrange
            var itemCodes = new List<string>() { "310120", "450040", "196380", "221160" };
            var sut = new DekomWebScraper();

            //Act
            var result = await sut.RunScrapingAsync(itemCodes);

            //Assert
            Assert.NotNull(result);
        }
    }
}
