using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompareApp.Core;
using Xunit;

namespace PriceCompareApp.Test
{
    public class ElkondTests
    {
        [Fact]
        public async void Get_product_data_for_item_codes()
        {
            //Arrange
            var itemCodes = new List<string>() { "8071", "6025", "6130", "8123" };
            var sut = new ElkondWebScraper(itemCodes);

            //Act
            var result = await sut.RunScrapingAsync();

            //Assert
            Assert.NotNull(result);
        }
    }
}
