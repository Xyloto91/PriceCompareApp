using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompareApp.Core.Scrapers;
using Xunit;

namespace PriceCompareApp.Test
{
    public class LorenTests
    {
        [Fact]
        public async void Get_products_for_item_codes()
        {
            //Arrange
            var itemCodes = new List<string>() { "328AD006", "339UN065" };
            var sut = new LorenWebScraper();

            //Act
            var result = await sut.RunScrapingAsync(itemCodes);

            //Assert
            Assert.NotNull(result);
        }
    }
}
