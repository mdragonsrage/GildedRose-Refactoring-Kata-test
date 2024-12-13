using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void foo()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal("foo", Items[0].Name);
    }

    public static IEnumerable<object[]> OneDayItems()
    {
        yield return 
        [ 
            new List<Item>
            {
                new() { Name = "Common Item", SellIn = 1, Quality = 1 },
                new() { Name = "Common Item", SellIn = 0, Quality = 10 },
                new() { Name = "Common Item", SellIn = -1, Quality = 10 },
            },
            new List<Item>
            {
                new() { Name = "Common Item", SellIn = 0, Quality = 0 },
                new() { Name = "Common Item", SellIn = -1, Quality = 8 },
                new() { Name = "Common Item", SellIn = -2, Quality = 8 },
            }
        ];

        yield return
        [
            new List<Item>
            {
                new() { Name = "Aged Brie", SellIn = 10, Quality = 10 },
                new() { Name = "Aged Brie", SellIn = 8, Quality = 50 },
                new() { Name = "Aged Brie", SellIn = 0, Quality = 10 },
                new() { Name = "Aged Brie", SellIn = -1, Quality = 10 },
            },
            new List<Item>
            {
                new() { Name = "Aged Brie", SellIn = 9, Quality = 11 },
                new() { Name = "Aged Brie", SellIn = 7, Quality = 50 },
                new() { Name = "Aged Brie", SellIn = -1, Quality = 12 },
                new() { Name = "Aged Brie", SellIn = -2, Quality = 12 },
            }
        ];

        yield return
        [
            new List<Item>
            {
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 15, Quality = 50 },
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 15, Quality = 51 },
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 5 },
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 5 },
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 5 },
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = -2, Quality = 5 },
            },
            new List<Item>
            {
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 15, Quality = 50 },
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 15, Quality = 51 },
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 5 },
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 5 },
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 5 },
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = -2, Quality = 5 },
            }
        ];

        yield return
        [
            new List<Item>
            {
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 0 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 0 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 1 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 0 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 1 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 10 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 10 },
            },
            new List<Item>
            {
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 14, Quality = 1 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 1 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 3 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 2 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 4 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 13 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -2, Quality = 0 },
            },
        ];
    }

    [Theory]
    [MemberData(nameof(OneDayItems))]
    public void ItemsAfterOneDayTest(List<Item> items, List<Item> expectedItems)
    {
        GildedRose app = new(items);
        app.UpdateQuality();
        Assert.Equivalent(expectedItems, items);
    }
    
    public static IEnumerable<object[]> VariousDaysItems()
    {
        yield return 
        [ 
            1,
            new List<Item> { new() { Name = "Common Item", SellIn = 1, Quality = 1 } },
            new List<Item> { new() { Name = "Common Item", SellIn = 0, Quality = 0 } }
        ];
        
        yield return 
        [ 
            2,
            new List<Item> { new() { Name = "Common Item", SellIn = 1, Quality = 1 } },
            new List<Item> { new() { Name = "Common Item", SellIn = -1, Quality = 0 } }
        ];
        
        yield return 
        [ 
            2,
            new List<Item> { new() { Name = "Common Item", SellIn = 1, Quality = 5 } },
            new List<Item> { new() { Name = "Common Item", SellIn = -1, Quality = 2 } }
        ];

        yield return
        [
            2,
            new List<Item>
            {
                new() { Name = "Aged Brie", SellIn = 10, Quality = 10 },
                new() { Name = "Aged Brie", SellIn = 8, Quality = 50 },
                new() { Name = "Aged Brie", SellIn = 1, Quality = 10 }
            },
            new List<Item>
            {
                new() { Name = "Aged Brie", SellIn = 8, Quality = 12 },
                new() { Name = "Aged Brie", SellIn = 6, Quality = 50 },
                new() { Name = "Aged Brie", SellIn = -1, Quality = 13 }
            }
        ];

        yield return
        [
            5,
            new List<Item>
            {
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 15, Quality = 50 },
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 5 },
            },
            new List<Item>
            {
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 15, Quality = 50 },
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 5 }
            }
        ];

        yield return
        [
            7,
            new List<Item>
            {
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 0 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 10 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 },
            },
            new List<Item>
            {
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 9 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -2, Quality = 0 },
            },
        ];
    }

    [Theory]
    [MemberData(nameof(VariousDaysItems))]
    public void ItemsAfterVariousDayTest(int days, List<Item> items, List<Item> expectedItems)
    {
        GildedRose app = new(items);
        int i = 0;
        for (; i < days; i++)
        {
            app.UpdateQuality();
        }
        Assert.Equivalent(expectedItems, items);
    }
}