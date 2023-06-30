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
        private RecipeGui _recipeGui;
        private readonly List<Recipe> _recipes;

        public RecipeGuiHandler(List<Recipe> recipes, RecipeGui recipeGui)
        {
            _recipes = recipes;
            _page = 1;
            _recipeGui = recipeGui;

            _pagination = new Pagination<Recipe>(_recipes, Slots);
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

        private void RefreshElements()
        {
            var items = _pagination.Search(_page);
            var hasNext = _pagination.Exists(_page + 1);
            var hasPrevious = false;

            if (_page == 1)
            {
                hasPrevious = true;
            }

            _recipeGui.Refresh(items, hasNext, hasPrevious);
        }
    }

    public class RecipeGui
    {
        private int _arrowPosition;
        private List<ComponentRecipeGui> _componentRecipeGuis;

        private GameObject _nextButton;
        private GameObject _previousButton;

        public RecipeGui()
        {
            _arrowPosition = 0;
            _componentRecipeGuis = new List<ComponentRecipeGui>();
        }

        public void Refresh(List<Recipe> recipes, bool hasNext, bool hasPrevious)
        {
            _nextButton.SetActive(hasNext);
            _previousButton.SetActive(hasPrevious);

            _arrowPosition = 0;

            for (var i = 0; i < recipes.Count; i++)
            {
                var recipe = recipes[i];
                var component = _componentRecipeGuis[i];
                var item = recipe.ItemFood;

                component.UpdateFoodName(item.Name, false);
            }

            _componentRecipeGuis[0].Visible();
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
    }
}