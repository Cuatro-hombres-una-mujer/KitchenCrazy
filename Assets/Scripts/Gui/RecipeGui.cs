using System.Collections.Generic;
using Helper;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.Gui
{
    public class RecipeGui
    {
        private int _arrowPosition;
        private List<ComponentRecipeGui> _componentRecipeGuis;

        public RecipeGui()
        {
            _arrowPosition = 0;
            _componentRecipeGuis = new List<ComponentRecipeGui>();
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