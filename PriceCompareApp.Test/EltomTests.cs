using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompareApp.Core;
using Xunit;

namespace PriceCompareApp.Test
{
    public class EltomTests
    {
        [Fact]
        public async void Get_product_data_for_item_codes()
        {
            //Arrange
            var itemCodes = new List<string>() { "6941", "4648", "405", "5469" };
            var sut = new EltomWebScraper(itemCodes); 

            //Act
            var result = await sut.RunScrapingAsync();

            //Assert
            Assert.NotNull(result);
        }
    }
}
