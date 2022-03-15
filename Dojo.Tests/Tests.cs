using System.Collections.Generic;
using System.Linq;
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
            var (sut, items) = Arrange(Item("Orange", 10, 10));

            sut.UpdateQuality();

            Assert.Equal(9, items[0].Quality);
            Assert.Equal(9, items[0].SellIn);
        }


        [Fact]
        public void GivenSellInDatePassed_QualityDegradesTwice()
        {
        }

        Item Item(string name, int quality, int sellIn) => new Item
        {
            Name = name,
            Quality = quality,
            SellIn = sellIn
        };

        (GildedRose.GildedRose sut, List<Item> items) Arrange(params Item[] items)
        {
            var itemList = items.ToList();
            return (new GildedRose.GildedRose(itemList), itemList);
        }

        public void UpdateQuality_AgedBrieIfQualityLessThan50ThenIncrementsBy1()
        {
            // Arrange
            var itemList = new List<Item>();

            var item = new Item()
            {
                Name = "Aged Brie",
                Quality = 49,
                SellIn = 10
            };
            
            itemList.Add(item);

            // Act
            var guildedRose = new GildedRose.GildedRose(itemList);
            guildedRose.UpdateQuality();

            // Assert
            Assert.Equal(50, itemList[0].Quality);
        }

        [Fact]
        public void GivenSulfuras_ThenQualityDoesntChange()
        {

        }
    }
}
