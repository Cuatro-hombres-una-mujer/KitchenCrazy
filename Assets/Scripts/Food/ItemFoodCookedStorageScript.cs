using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Food
{
    public class ItemFoodCookedStorageScript : MonoBehaviour
    {

        private const string FileName = "item_food_cook.json";
        private const string Root = "Assets/Json/";
        
        private static ItemFoodCookedStorage _itemFoodCookedStorage;
        
        private void Start()
        {
            _itemFoodCookedStorage = new ItemFoodCookedStorage();
            var definitivePath = FileName + Root;
            
            var itemsCooked  = 
                JsonConvert.DeserializeObject<List<ItemFoodCooked>>(definitivePath);

            foreach (var itemCooked in itemsCooked)
            {
                _itemFoodCookedStorage.Register(itemCooked);
                Debug.Log("Registered Item Cooked");
            }
            
            
        }

        public static ItemFoodCookedStorage ItemFoodCookedStorage()
        {
            return _itemFoodCookedStorage;
        }

    }
    
}