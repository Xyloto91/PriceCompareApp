using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompareApp.Core.Scrapers;
using Xunit;

namespace PriceCompareApp.Test
{
    public class StatusFrigoTests
    {
        [Fact]
        public async void Get_products_data_for_item_codes()
        {
            //Arrange
            var itemCodes = new List<string>() { "0101228", "010155", "0101213", "050604" };
            var sut = new StatusFrigoWebScraper(null);
            
            //Act
            var result = await sut.RunScrapingAsync(itemCodes);

            //Assert
            Assert.NotNull(result);
        }
    }
}
