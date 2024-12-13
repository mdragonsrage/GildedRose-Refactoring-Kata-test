using GildedRoseKata;

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using VerifyXunit;

using Xunit;

namespace GildedRoseTests;

public class ApprovalTest
{
    [Fact]
    public Task Foo()
    {
        Item[] items = 
        { 
            new Item { Name = "foo", SellIn = 0, Quality = 0 },
        };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        
        return Verifier.Verify(items);
    }

    [Fact]
    public Task BaseApproval()
    {
        Item[] items =
        {
            new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 5 },
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 0 },
            new Item { Name = "Generic Item", SellIn = 10, Quality = 5}
        };
        
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        
        return Verifier.Verify(items);
    }
    
    [Fact]
    public Task ThirtyDays()
    {
        var fakeoutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeoutput));
        Console.SetIn(new StringReader($"a{Environment.NewLine}"));

        Program.Main(new string[] { "30" });
        var output = fakeoutput.ToString();

        return Verifier.Verify(output);
    }
}