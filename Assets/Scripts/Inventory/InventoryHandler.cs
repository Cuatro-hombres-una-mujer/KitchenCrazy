using System.Collections;
using System.Collections.Generic;
using Food;
using UnityEngine;

public class InventoryHandler
{
    private readonly List<ItemFood> _items;
    private readonly IDictionary<string, int> _positions;

    public InventoryHandler()
    {
        _items = new List<ItemFood>();
    }

    public void AddItem(ItemFood itemAdded)
    {
        var name = itemAdded.GetName();
        if (HasItem(itemAdded))
        {
            ItemFood itemFood = GetItem(name);

            itemFood.SetQuantity(
                itemFood.GetQuantity() + itemAdded.GetQuantity()
            );

            return;
        }

        _items.Add(itemAdded);
        var position = _items.Count - 1;

        _positions[name] = position;
    }

    public void DeleteItem(ItemFood item)
    {
        var name = item.GetName();

        if (!HasItem(item))
        {
            return;
        }

        var position = _positions[name];

        _positions.Remove(name);
        _items.RemoveAt(position);

    }

    public bool HasItem(ItemFood item)
    {
        return _positions.ContainsKey(item.GetName());
    }

    public ItemFood GetItem(int slot)
    {
        return _items[slot];
    }

    public ItemFood GetItem(string name)
    {
        var position = _positions[name];
        return _items[position];
    }

    public bool HasElementOrSuperior(ItemFood itemFood)
    {

        var name = itemFood.GetName();

        if (!HasItem(itemFood))
        {
            return false;
        }
        
        var item = GetItem(name);
        return item.GetQuantity() >= itemFood.GetQuantity();
    }

    public List<ItemFood> GetItems()
    {
        return _items;
    }
}