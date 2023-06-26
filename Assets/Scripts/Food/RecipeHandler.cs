using System.Collections.Generic;

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
            
            _recipes.Add(itemFood.Name, recipe);
        }

        public Recipe Get(string name)
        {
            return _recipes[name];
        }
        
    }
    
}