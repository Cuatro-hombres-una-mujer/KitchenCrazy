using System;
using System.Collections.Generic;
using UnityEngine;

namespace Food
{
    public class ItemFoodStorage
    {
        private readonly IDictionary<string, ItemFood> _itemsRegistered;

        public ItemFoodStorage()
        {
            _itemsRegistered = new Dictionary<string, ItemFood>();
        }

        public void Register(ItemFood itemFood)
        {
            
            if (_itemsRegistered.ContainsKey(itemFood.Name))
            {
                throw new Exception("The food already is registered");
            }
            
            _itemsRegistered[itemFood.Name] = itemFood;
        }

        public ItemFood Get(string name)
        {
            return _itemsRegistered[name];
        }
        
    }
}