using System;
using System.Collections;
using System.Collections.Generic;
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

        [SerializeField] private GameObject arrowFirstText;
        [SerializeField] private GameObject arrowSecondText;
        [SerializeField] private GameObject arrowThirdText;

        [SerializeField] private TextMeshProUGUI infoText;

        [SerializeField] private GameObject buttonNext;
        [SerializeField] private GameObject buttonPrevious;

        private static RecipeGuiHandler _recipeGuiHandler;

        private const string InventoryName = "recipe_inventory";
        private List<Recipe> _recipes;
        private Player _player;

        public void Awake()
        {
            StartCoroutine(AwakeWaiting());
        }

        private IEnumerator AwakeWaiting()
        {
            yield return new WaitForSeconds(1f);


            _player = PlayerMovement.GetPlayer();
            var recipeHandler = ItemFoodStorageRecipeScript.GetRecipeHandler();
            
            _recipes = recipeHandler.GetRecipes();
            var recipeGui = new RecipeGui(buttonNext, buttonPrevious, infoText);

            Debug.Log("> " + _recipes.Count);
            _recipeGuiHandler = new RecipeGuiHandler(_recipes, recipeGui);

            recipeGui.AddComponentRecipeGui(
                new ComponentRecipeGui(firstText, arrowFirstText, false));

            recipeGui.AddComponentRecipeGui(
                new ComponentRecipeGui(secondText, arrowSecondText, false));

            recipeGui.AddComponentRecipeGui(
                new ComponentRecipeGui(thirdText, arrowThirdText, false));

            _recipeGuiHandler.RefreshElements();
        }

        public void Update()
        {
            if (_player == null)
            {
                return;
            }

            if (_player.HasOpenInventory() && _player.GetOpenedInventory() == InventoryName)
            {
                var recipeGui = _recipeGuiHandler.GetRecipeGui();

                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    recipeGui.Next();
                }

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    recipeGui.Left();
                }
            }
        }

        public static RecipeGuiHandler GetRecipeGuiHandler()
        {
            return _recipeGuiHandler;
        }

        public void NextOnClickButton()
        {
            _recipeGuiHandler.NextPage();
        }

        public void PreviousOnClickButton()
        {
            _recipeGuiHandler.PreviousPage();
        }
        
    }
}