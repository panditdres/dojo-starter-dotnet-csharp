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
            var (sut, items) = Arrange(Item("Orange", 10, -1));

            sut.UpdateQuality();

            Assert.Equal(8, items[0].Quality);
            Assert.Equal(-2, items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_AgedBrieIfQualityLessThan50ThenIncrementsBy1()
        {
            // Arrange
            var (sut, items) = Arrange(Item("Aged Brie", 49, 10));

            sut.UpdateQuality();
            
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void GivenLegendaryItem_ThenQualityAndSellInDontChange()
        {
            var (sut, items) = Arrange(Item("Sulfuras, Hand of Ragnaros", 40, 0));

            sut.UpdateQuality();

            Assert.Equal(40, items[0].Quality);
            Assert.Equal(0, items[0].SellIn);
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
    }
}
