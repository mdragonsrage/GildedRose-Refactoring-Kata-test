﻿using System.Collections.Generic;

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
                UpdateBackstagePasses(item);
                break;
            case "Sulfuras, Hand of Ragnaros":
                UpdateSellIn(item);
                break;
            case "Conjured Mana Cake":
                UpdateConjured(item);
                break;
            default:
                UpdateCommon(item);
                break;
        };
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
        DegradeCommonQuality(item);
    }

    private static void UpdateConjured(Item item)
    {
        UpdateSellIn(item);
        DegradeCommonQuality(item);
        DegradeCommonQuality(item);
    }

    private static void DegradeCommonQuality(Item item)
    {
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

    private static void UpdateBackstagePasses(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;
        }
        
        if (item.SellIn < 11 && item.Quality < 50)
        {
            item.Quality += 1;
        }

        if (item.SellIn < 6 && item.Quality < 50)
        {
            item.Quality += 1;
        }
        
        UpdateSellIn(item);
        if (item.SellIn >= 0) return;
        item.Quality = 0;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            UpdateQualityForItem(item);
        }
    }
}