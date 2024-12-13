using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    private static void UpdateQualityForItem(Item item)
    {
        string name = item.Name;
        switch (name)
        {
            case "Aged Brie":
                UpdateBrie(item);
                break;
            case "Backstage passes to a TAFKAL80ETC concert": 
            case "Sulfuras, Hand of Ragnaros":
                    DefaultMethod(item);
                break;
            default:
                UpdateCommon(item);
                break;
        };
        
        //DefaultMethod(item);
    }

    private static void DefaultMethod(Item item)
    {
        if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
        {
            if (item.Quality > 0)
            {
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.Quality = item.Quality - 1;
                }
            }
        }
        else
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;

                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.SellIn < 11)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }

                    if (item.SellIn < 6)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }
        }

        UpdateSellIn(item);

        if (item.SellIn < 0)
        {
            if (item.Name != "Aged Brie")
            {
                if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }
                else
                {
                    item.Quality = item.Quality - item.Quality;
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }
    }

    private static void UpdateSellIn(Item item)
    {
        if (item.Name != "Sulfuras, Hand of Ragnaros")
        {
            item.SellIn -= 1;
        }
    }

    private static void UpdateCommon(Item item)
    {
        UpdateSellIn(item);
        if (item.Quality <= 0) return;
        item.Quality -= 1;
        if (item.SellIn < 0 && item.Quality > 0)
        {
            item.Quality -= 1;
        }
    }

    private static void UpdateBrie(Item item)
    {
        UpdateSellIn(item);
        if (item.Quality >= 50) return;
        item.Quality += 1;
        if (item.SellIn < 0)
        {
            item.Quality += 1;
        }

    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            UpdateQualityForItem(item);
        }
    }
}