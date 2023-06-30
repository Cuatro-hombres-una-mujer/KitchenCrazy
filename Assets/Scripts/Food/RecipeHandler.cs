using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Food
{
    public class RecipeHandler
    {
        private readonly IDictionary<string, Recipe> _recipes;

        public RecipeHandler()
        {
            _recipes = new Dictionary<string, Recipe>();
        }

        public void Register(Recipe recipe)
        {
            var itemFood = recipe.ItemFood;

            if (itemFood == null)
            {
                Debug.Log("Es null");
                return;
            }

            Debug.Log("Registered R");
            _recipes.Add(itemFood.Name, recipe);
        }

        public Recipe Get(string name)
        {
            return _recipes[name];
        }

        public List<Recipe> GetRecipes()
        {

            Debug.Log("A: " + _recipes.Count);
            var recipesInList = new List<Recipe>();
            
            foreach (var recipesValue in _recipes.Values)
            {
                recipesInList.Add(recipesValue);
            }

            return recipesInList;
        }
    }
}