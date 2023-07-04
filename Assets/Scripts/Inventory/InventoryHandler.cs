using System.Collections;
using System.Collections.Generic;
using System.Text;
using Food;
using Helper;
using UnityEngine;

public class Inventory
{
    
    //private readonly List<ItemFood> _items;
    private readonly IDictionary<string, ItemFood> _items;

    public Inventory()
    {
        //_items = new List<ItemFood>();
        _items = new Dictionary<string, ItemFood>();
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

        _items[name] = itemAdded;
    }

    public void DeleteItem(ItemFood item)
    {
        var name = item.Name;

        if (!HasItem(item))
        {
            return;
        }

        var itemSearched = _items[name];
        
        if (itemSearched.IsUnique())
        {
            _items.Remove(name);
            return;
        }
        
        itemSearched.Remove(item.Quantity);
    }

    public bool HasItem(ItemFood item)
    {
        return _items.ContainsKey(item.Name);
    }
    
    public ItemFood GetItem(string name)
    {
        return _items[name];
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
        var itemsFoodList = new List<ItemFood>(_items.Values);

        return itemsFoodList;
    }

    public string GetItemsInString()
    {
        if (_items.Count == 0)
        {
            return "Nada :(";
        }

        var stringBuilder = new StringBuilder();
        foreach (var item in GetItems())
        {
            stringBuilder.Append(item.Name).Append(StringHelper.SpaceLine);
        }

        return stringBuilder.ToString();
    }
}