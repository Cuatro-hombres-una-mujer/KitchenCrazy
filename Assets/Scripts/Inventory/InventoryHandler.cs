using System.Collections;
using System.Collections.Generic;
using Food;
using UnityEngine;

public class InventoryHandler
{
    private readonly List<ItemFood> _items;

    public InventoryHandler()
    {
        _items = new List<ItemFood>();
    }

    public void AddItem(ItemFood itemAdded)
    {
        foreach (var item in _items)
        {
            if (itemAdded.Equals(item))
            {
                itemAdded.SetQuantity(itemAdded.GetQuantity() +
                                      itemAdded.GetQuantity());
            }
        }

        _items.Add(itemAdded);
    }

    public void RemoveItem(ItemFood item)
    {
        _items.Remove(item);
    }

    public bool HasItem(ItemFood item)
    {
        return _items.Contains(item);
    }

    public ItemFood GetItem(int slot)
    {
        return _items[slot];
    }
    
}