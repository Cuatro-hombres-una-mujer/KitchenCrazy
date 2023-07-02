using System.Collections;
using System.Collections.Generic;
using System.Text;
using Food;
using Helper;
using UnityEngine;

public class Inventory
{
    private readonly List<ItemFood> _items;
    private readonly IDictionary<string, int> _positions;

    public Inventory()
    {
        _items = new List<ItemFood>();
        _positions = new Dictionary<string, int>();
    }

    public void AddItem(ItemFood itemAdded)
    {
        var name = itemAdded.Name;
        if (HasItem(itemAdded))
        {
            ItemFood itemFood = GetItem(name);

            itemFood.Quantity = itemFood.Quantity + itemAdded.Quantity;


            return;
        }

        _items.Add(itemAdded);
        var position = _items.Count - 1;

        _positions[name] = position;
    }

    public void DeleteItem(ItemFood item)
    {
        var name = item.Name;

        if (!HasItem(item))
        {
            return;
        }

        var position = _positions[name];
        var itemSearched = _items[position];

        if (itemSearched.IsUnique())
        {
            _positions.Remove(name);
            _items.RemoveAt(position);
            return;
        }
        
        itemSearched.Remove(item.Quantity);
    }

    public bool HasItem(ItemFood item)
    {
        return _positions.ContainsKey(item.Name);
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
        var name = itemFood.Name;

        if (!HasItem(itemFood))
        {
            return false;
        }

        var item = GetItem(name);
        return item.Quantity >= itemFood.Quantity;
    }

    public List<ItemFood> GetItems()
    {
        return _items;
    }

    public string GetItemsInString()
    {
        if (_items.Count == 0)
        {
            return "Nada :(";
        }

        var stringBuilder = new StringBuilder();
        foreach (var item in _items)
        {
            stringBuilder.Append(item.Name).Append(StringHelper.SpaceLine);
        }

        return stringBuilder.ToString();
    }
}