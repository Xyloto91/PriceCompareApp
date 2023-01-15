using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompareApp.Core.Scrapers;
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
            var sut = new EltomWebScraper(); 

            //Act
            var result = await sut.RunScrapingAsync(itemCodes);

            //Assert
            Assert.NotNull(result);
        }
    }
}
