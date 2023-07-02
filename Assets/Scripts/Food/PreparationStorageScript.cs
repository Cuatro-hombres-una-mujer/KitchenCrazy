using System;
using System.Collections.Generic;
using System.IO;
using Helper;
using Newtonsoft.Json;
using UnityEngine;

namespace Food
{
    public class PreparationStorageScript : MonoBehaviour
    {

        private static PreparationStorage _preparationStorage;
        private const string Root = "Assets/Json/";
        private const string FileName = "preparation.json";
        
        public void Awake()
        {
            _preparationStorage = new PreparationStorage();
            var recipes = JsonHelper.GetAsJson<Preparation>(Root, FileName);
            
            foreach (var recipe in recipes)
            {
                print("Preparation registered");
                _preparationStorage.Register(recipe);
            }
            
        }

        public static PreparationStorage GetPreparationStorage()
        {
            return _preparationStorage;
        }

    }
    
}