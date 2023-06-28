using System;
using Entities.Player;
using UnityEngine;

namespace Food
{
    public class ButtonRecipe : MonoBehaviour
    {

        private Player _player;
        private RecipeHandler _recipeHandler;

        private void Awake()
        {
            _player = PlayerMovement.GetPlayer();
            _recipeHandler = ItemFoodStorageRecipeScript.GetRecipeHandler();
        }

        public void CookAtRecipe(string name)
        {

            var recipe = _recipeHandler.Get(name);
            var inventory = _player.Inventory;

            if (recipe.HasElements(inventory))
            {
                recipe.Cook(inventory);
                return;
            }
            //Hacer algo si no tiene los items de cocinar
        }
        
    }
    
}