using System;
using System.Collections.Generic;
using Dojo.GildedRose;
using Xunit;

namespace Dojo.Tests
{
    public class Tests
    {
        [Fact]
        public void StarterTest()
        {
            Assert.True(Solution.IsSetup);
        }

        [Fact]
        public void GivenEndOfDay_ReduceQualityAndSellIn()
        {
            // Arrange
            var itemList = new List<Item>();

            var item = new Item()
            {
                Name = "Orange",
                Quality = 10,
                SellIn = 10
            };

            itemList.Add(item);

            var guildedRose = new GildedRose.GildedRose(itemList);

            // Act
            guildedRose.UpdateQuality();

            // Assert
            Assert.Equal(9, itemList[0].Quality);
            Assert.Equal(9, itemList[0].SellIn);
        }

        [Fact]
        public void GivenSellInDatePassed_QualityDegradesTwice()
        {

        }
    }
}
