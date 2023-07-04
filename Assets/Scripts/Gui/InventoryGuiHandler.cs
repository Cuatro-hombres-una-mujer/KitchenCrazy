using System.Collections.Generic;
using Food;
using Helper;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.Gui
{

    public interface IInventoryGuiHandler
    {

        void AddPart(PartInventoryGuiHandler partInventoryGuiHandler);

        void Down();

        void Up();

        ItemFood GetItemSelected();

        bool ItemSelectedIsEmpty();

        void Refresh();

    }
    
    public class InventoryGuiHandler : IInventoryGuiHandler
    {

        private int _slot = 0;
        private int _positionSelected;
        private int _page;
        private int _lastPositionInsertedText;

        private readonly Inventory _inventory;
        private readonly List<PartInventoryGuiHandler> _parts;
        private List<ItemFood> _actualItemsSearched;
        private Pagination<ItemFood> _pagination;

        private readonly GameObject _nextPageButton;
        private readonly GameObject _previousPageButton;

        public InventoryGuiHandler(Inventory inventory, int slot, GameObject nextPageButton,
            GameObject previousPageButton)
        {
            _slot = slot;
            _inventory = inventory;
            _parts = new List<PartInventoryGuiHandler>();
            _page = 1;
            _positionSelected = 0;
            _nextPageButton = nextPageButton;
            _previousPageButton = previousPageButton;
        }

        public void AddPart(PartInventoryGuiHandler part)
        {
            _parts.Add(part);
        }

        public void NextPage()
        {
            _page++;
            Refresh();
        }

        public void PreviousPage()
        {
            _page--;
            Refresh();
        }

        public void Up()
        {

            if (_actualItemsSearched.Count == 0)
            {
                return;
            }
            
            _parts[_positionSelected].Deselect();
            
            if (_positionSelected == 0)
            {
                _positionSelected = _lastPositionInsertedText;
            }
            else
            {
                _positionSelected--;
            }
            
            _parts[_positionSelected].Select();
        }

        public void Down()
        {

            if (ItemSelectedIsEmpty())
            {
                return;
            }
            
            _parts[_positionSelected].Deselect();

            if (_positionSelected == _lastPositionInsertedText)
            {
                _positionSelected = 0;
            }
            else
            {
                _positionSelected++;
            }
            
            _parts[_positionSelected].Select();
        }

        public bool ItemSelectedIsEmpty()
        {
            return _actualItemsSearched.Count == 0;
        }

        public void Refresh()
        {
            _pagination = Pagination<ItemFood>.Of(_inventory.GetItems(), _slot);

            foreach (var parts in _parts)
            {
                parts.HideLine();
            }

            var items = _pagination.Search(_page);
            _actualItemsSearched = items;
            _lastPositionInsertedText = -1;
            
            for (var i = 0; i < _parts.Count; i++)
            {

                if (i > items.Count - 1)
                {
                    break;
                }
                
                var item = items[i];
                var part = _parts[i];
                
                part.UpdateItem(item);
                _lastPositionInsertedText++;
            }

            if (_page == 1)
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
                _nextPageButton.SetActive(false);
            }

            if (!ItemSelectedIsEmpty())
            {
                _parts[0].Select();
            }
            
            
        }

        public ItemFood GetItemSelected()
        {
            return _actualItemsSearched[_positionSelected];
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

        public void HideLine()
        {
            _contentText.text = "";
            _arrow.SetActive(false);
        }
        
    }

}
