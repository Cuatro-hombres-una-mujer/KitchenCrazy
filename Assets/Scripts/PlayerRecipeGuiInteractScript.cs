using System;
using DefaultNamespace.Gui;
using Entities.Player;
using Food;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerRecipeGuiInteractScript : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI firstText;
        [SerializeField] private TextMeshProUGUI secondText;
        [SerializeField] private TextMeshProUGUI thirdText;
        
        private static RecipeGuiHandler _recipeGuiHandler;
        
        private const string InventoryName = "recipe_inventory";
        private int _page = 1;
        private Player _player;

        public void Awake()
        {
            _player = PlayerMovement.GetPlayer();

            var recipeHandler = ItemFoodStorageRecipeScript.GetRecipeHandler();
            var recipes = recipeHandler.GetRecipes();

            var recipeGui = new RecipeGui();
            
            _recipeGuiHandler = new RecipeGuiHandler(recipes, recipeGui);
        }

        public void Update()
        {
            if (_player.HasOpenInventory() && _player.GetOpenedInventory() == InventoryName)
            {
                
                var recipeGui = _recipeGuiHandler.GetRecipeGui();
                
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    recipeGui.Next();
                }

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    recipeGui.Left();
                }

            }   
            
        }

        public static RecipeGuiHandler GetRecipeGuiHandler()
        {
            return _recipeGuiHandler;
        }
        
        
    }
}