using System;
using System.Collections.Generic;
using System.IO;
using Helper;
using Newtonsoft.Json;
using UnityEngine;

namespace Food
{
    public class ItemFoodStorageRecipeScript : MonoBehaviour
    {

        private static RecipeHandler _recipeHandler;
        private const string FileName = "recipes.json";
        private void Awake()
        {
            _recipeHandler = new RecipeHandler();

            IEnumerable<string> lines = File.ReadLines(FileName);
            var jsonInString = StringHelper.ConvertToString(lines);

            var recipes = JsonConvert.DeserializeObject< List<Recipe>> (jsonInString);

            foreach (var recipe in recipes)
            {
                _recipeHandler.Register(recipe);
            }

        }

        public static RecipeHandler GetRecipeHandler()
        {
            return _recipeHandler;
        }

    }

}