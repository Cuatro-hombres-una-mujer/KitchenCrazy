using System.Collections.Generic;
using Food;
using Helper;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.Gui
{
    public class InventoryGuiHandler
    {

        private int _positionSelected;
        private int _page;
        
        private readonly List<PartInventoryGuiHandler> _parts;
        private readonly Pagination<ItemFood> _pagination;

        private GameObject _nextPageButton;
        private GameObject _previousPageButton;

        public InventoryGuiHandler(List<ItemFood> items, int slot)
        {
            _parts = new List<PartInventoryGuiHandler>();
            _page = 1;
            _positionSelected = 0;
            _pagination = Pagination<ItemFood>.Of(items, slot);
        }

        public void AddPart(PartInventoryGuiHandler part)
        {
            _parts.Add(part);
        }

        public void NextPage()
        {
            _page++;
            Show();
        }

        public void PreviousPage()
        {
            _page--;
            Show();
        }

        public void Up()
        {

            _parts[_positionSelected].Deselect();
            
            if (_positionSelected == 0)
            {
                _positionSelected = _parts.Count - 1;
            }
            else
            {
                _positionSelected++;
            }
            
            _parts[_positionSelected].Select();
        }

        public void Down()
        {
            
            _parts[_positionSelected].Deselect();

            if (_positionSelected == (_parts.Count - 1))
            {
                _positionSelected = 0;
            }
            else
            {
                _positionSelected--;
            }
            
            _parts[_positionSelected].Select();
        }

        public void Show()
        {
            var items = _pagination.Search(_page);

            for (var i = 0; i < _parts.Count; i++)
            {
                var item = items[i];
                var part = _parts[i];
                
                part.UpdateItem(item);
            }

            if (_page != 1)
            {
                _previousPageButton.SetActive(false);
            }
            else
            {
                _previousPageButton.SetActive(true);
            }

            if (_pagination.Exists(_page + 1))
            {
                _nextPageButton.SetActive(true);
            }
            else
            {
                _previousPageButton.SetActive(false);
            }
         
            
            
        }
        
        
}
    public class PartInventoryGuiHandler
    {

        private readonly TextMeshProUGUI _contentText;
        private readonly GameObject _arrow;

        public PartInventoryGuiHandler(TextMeshProUGUI contentText,
            GameObject arrow)
        {
            _contentText = contentText;
            _arrow = arrow;
            
            _arrow.SetActive(false);
        }

        public void UpdateItem(ItemFood itemFood)
        {
            _contentText.text = itemFood.Name + " - " + itemFood.Quantity;
        }

        public void Select()
        {
            _arrow.SetActive(true);
        }

        public void Deselect()
        {
            _arrow.SetActive(false);       
        }
        
    }

}
