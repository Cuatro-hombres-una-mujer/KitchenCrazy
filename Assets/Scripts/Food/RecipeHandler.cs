using System;
using System.Collections.Generic;
using System.Linq;

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
                Console.WriteLine("Es null");
                return;
            }

            _recipes.Add(itemFood.Name, recipe);
        }

        public Recipe Get(string name)
        {
            return _recipes[name];
        }

        public List<Recipe> GetRecipes()
        {
            return _recipes.Values.ToList();
        }
    }
}