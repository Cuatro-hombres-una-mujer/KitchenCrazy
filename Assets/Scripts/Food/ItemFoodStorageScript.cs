using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Helper;
using UnityEngine;
using Newtonsoft.Json;


using File = System.IO.File;

namespace Food
{
    public class ItemFoodStorageScript : MonoBehaviour
    {
        private static ItemFoodStorage _itemFoodStorage;
        private const string FileName = "items_food.js";

        private void Awake()
        {
            _itemFoodStorage = new ItemFoodStorage();
            IEnumerable lines = File.ReadLines(FileName);

            var jsonInString = StringHelper.ConvertToString(lines);

            var items = JsonConvert.DeserializeObject<List<ItemFood>>(jsonInString);
            foreach (var itemFood in items)
            {
                _itemFoodStorage.Register(itemFood);
            }
            
        }
        
        public static ItemFoodStorage GetItemFoodStorage()
        {
            return _itemFoodStorage;
        }
        
    }
}