using System.Collections.Generic;
using Food;
using Helper;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.Gui
{
    public class RecipeGuiHandler
    {
        private const int Slots = 3;
        private Pagination<Recipe> _pagination;
        private int _page;
        private readonly RecipeGui _recipeGui;

        public RecipeGuiHandler(List<Recipe> recipes, RecipeGui recipeGui)
        {
            _page = 1;
            _recipeGui = recipeGui;

            _pagination = new Pagination<Recipe>(recipes, Slots);
        }

        public RecipeGui GetRecipeGui()
        {
            return _recipeGui;
        }

        public void NextPage()
        {
            _page++;
            RefreshElements();
        }

        public void PreviousPage()
        {
            _page--;
            RefreshElements();
        }

        public void  RefreshElements()
        {
            var items = _pagination.Search(_page);
            var hasNext = _pagination.Exists(_page + 1);
            var hasPrevious = true;

            if (_page == 1)
            {
                hasPrevious = false;
            }

            _recipeGui.Refresh(items, hasNext, hasPrevious);
        }
    }

    public class RecipeGui
    {

        private TextMeshProUGUI _infoText;
        private int _arrowPosition;
        private readonly List<ComponentRecipeGui> _componentRecipeGuis;
        private List<Recipe> _recipes;

        private readonly GameObject _nextButton;
        private readonly GameObject _previousButton;

        public RecipeGui(GameObject nextButton, GameObject previousButton, TextMeshProUGUI infoText)
        {
            _nextButton = nextButton;
            _previousButton = previousButton;
            
            _arrowPosition = 0;
            _componentRecipeGuis = new List<ComponentRecipeGui>();
            _infoText = infoText;
        }

        public void AddComponentRecipeGui(ComponentRecipeGui componentRecipeGui)
        {
            _componentRecipeGuis.Add(componentRecipeGui);
        }

        private void BlankLines()
        {
            foreach (var component in _componentRecipeGuis)
            {
                component.EmptyLine();
            }
        }
        
        public void Refresh(List<Recipe> recipes, bool hasNext, bool hasPrevious)
        {
            
            BlankLines();

            _nextButton.SetActive(hasNext);
            _previousButton.SetActive(hasPrevious);

            _arrowPosition = 0;
            
            Debug.Log("Recipes: " + recipes.Count);

            for (var i = 0; i < recipes.Count; i++)
            {
                
                var recipe = recipes[i];
                var component = _componentRecipeGuis[i];
                var item = recipe.ItemFood;
                Debug.Log("Insertando receta comida: " + item.Name);
                
                component.UpdateFoodName(item.Name, false);
            }

            _componentRecipeGuis[0].Visible();
            _recipes = recipes;
        }

        public void Next()
        {
            GetComponentInArrow().Invisible();
            var lastPosition = ListHelper.GetLastPositionInCollection(_componentRecipeGuis);

            if (_arrowPosition == lastPosition)
            {
                _arrowPosition = 0;
            }
            else
            {
                _arrowPosition++;
            }

            GetComponentInArrow().Visible();
            ShowIngredients();
        }

        public Recipe GetViewingRecipe()
        {
            return _recipes[_arrowPosition];
        }
        
        public void Left()
        {
            GetComponentInArrow().Invisible();

            if (_arrowPosition == 0)
            {
                _arrowPosition = ListHelper.GetLastPositionInCollection(_componentRecipeGuis);
            }
            else
            {
                _arrowPosition--;
            }

            GetComponentInArrow().Visible();
            ShowIngredients();
        }

        private void ShowIngredients()
        {
            var recipe = _recipes[_arrowPosition];

            _infoText.text = ItemHelper.GenerateListItems(recipe.Items);
        }
        
        public ComponentRecipeGui GetComponentInArrow()
        {
            return _componentRecipeGuis[_arrowPosition];
        }
    }

    public class ComponentRecipeGui
    {
        private readonly TextMeshProUGUI _text;
        private GameObject Arrow { get; }

        public ComponentRecipeGui(TextMeshProUGUI text, GameObject arrow, bool isSelected)
        {
            _text = text;
            Arrow = arrow;

            arrow.SetActive(isSelected);
        }

        public void UpdateFoodName(string foodName, bool isSelected)
        {
            _text.text = foodName;
            Arrow.SetActive(isSelected);
        }

        public void Visible()
        {
            Arrow.SetActive(true);
        }

        public void Invisible()
        {
            Arrow.SetActive(false);
        }

        public void EmptyLine()
        {
            _text.text = "";
        }
        
    }
}