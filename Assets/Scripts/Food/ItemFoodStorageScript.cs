using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Food.Order;
using Helper;
using UnityEngine;
using Newtonsoft.Json;
using File = System.IO.File;

namespace Food
{
    public class ItemFoodStorageScript : MonoBehaviour
    {
        private static ItemFoodStorage _itemFoodStorage;
        private const string Root = "Assets/Json/";
        private const string FileName = "items_food.json";

        private static OrderGenerator _orderGenerator;

        private void Awake()
        {
            _itemFoodStorage = new ItemFoodStorage();
            
            
            var items = JsonHelper.GetAsJson<ItemFood>(Root, FileName);
            
            foreach (var itemFood in items)
            {
                _itemFoodStorage.Register(itemFood);
            }
            
            _orderGenerator = new OrderGenerator(items);
        }

        public static ItemFoodStorage GetItemFoodStorage()
        {
            return _itemFoodStorage;
        }

        public static OrderGenerator GetOrderGenerator()
        {
            return _orderGenerator;
        }
        
    }
}