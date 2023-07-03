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
        private const string Root = "Assets/Json/";
        private const string FileName = "recipes.json";
        private void Awake()
        {
            _recipeHandler = new RecipeHandler();

            var recipes = JsonHelper.GetAsJson<Recipe>(Root, FileName);

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