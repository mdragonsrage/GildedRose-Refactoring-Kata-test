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

    public static IEnumerable<object[]> BaseItems()
    {
        yield return new object[] { new Item { Name = "foo", SellIn = 0, Quality = 0 },  };
    }
    
    [Theory]
    [MemberData(nameof)]
}