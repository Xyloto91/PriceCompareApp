using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompareApp.Common;
using PriceCompareApp.Core.Scrapers;
using Xunit;

namespace PriceCompareApp.Test
{
    public class VrecoolTests
    {
        [Fact]
        public async void Get_product_data_by_item_codes()
        {
            //Arrange
            var itemCodes = new List<string>() { "8040", "8001", "8071", "4583" };
            var sut = new VrecoolWebScraper();

            //Act
            var result = await sut.RunScrapingAsync(itemCodes);

            //Assert
            Assert.NotNull(result);
        }
    }
}
