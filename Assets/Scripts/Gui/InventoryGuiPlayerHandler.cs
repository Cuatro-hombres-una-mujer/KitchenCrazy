using System.Collections.Generic;
using Food;
using UnityEngine;

namespace DefaultNamespace.Gui
{ 
    public class InventoryGuiPlayerHandler : IInventoryGuiHandler
    {

        private const int NumberElements = 5;
        private readonly List<PartInventoryGuiHandler> _parts;
        private List<ItemFood> _itemsViewing;
        private int _index;

        private int _low;
        private int _height;
        
        private readonly Inventory _inventory;

        public InventoryGuiPlayerHandler(Inventory inventory)
        {
            _parts = new List<PartInventoryGuiHandler>();
            _inventory = inventory;
            _index = 0;
        }

        public void Open(Inventory inventory)
        {
            _parts[0].Select();
            UpdateListItemsViewing(0, NumberElements);
        }

        private void UpdateListItemsViewing(int low, int height)
        {
            var items = _inventory.GetItems();

            if (items.Count < height)
            {
                _itemsViewing = items;
                return;
            }
            
            _low = low;
            _height = height;
            
            Debug.Log("low: " + _low);
            Debug.Log("Items: " + items.Count);
            
            _itemsViewing = items.GetRange(low, NumberElements);
        }

        public void Close()
        {
            _parts[_index].Deselect();
            _index = 0;
            _itemsViewing = null;
        }
        
        public void AddPart(PartInventoryGuiHandler partInventoryGuiHandler)
        {
            _parts.Add(partInventoryGuiHandler);
        }

        public void Down()
        {
            
            if (_index == (_itemsViewing.Count - 1))
            {

                var inventory = _inventory.GetItems();
                if (_height + 1 > inventory.Count)
                {
                    return;
                }
                
                UpdateListItemsViewing(_low + 1, _height + 1);
                _index = _itemsViewing.Count - 1;
                Refresh();
                return;
            }
            
            _parts[_index].Deselect();
            _parts[_index + 1].Select();
            _index++;
        }

        public void Up()
        {

            if (_index == 0)
            {

                if (_low == 0)
                {
                    return;
                }
                
                UpdateListItemsViewing(_low - 1, _height - 1);
                _index = 0;
                
                Refresh();
                return;
            }
            
            Debug.Log("Index: " + _index);
            
            _parts[_index].Deselect();
            _parts[_index - 1].Select();
            _index--;
        }

        public ItemFood GetItemSelected()
        {
            return null;
        }

        public bool ItemSelectedIsEmpty()
        {
            return false;
        }

        public void Refresh()
        {
            
            for (var i = 0; i < _itemsViewing.Count; i++)
            {
                
                var item = _itemsViewing[i];
                var part = _parts[i];
                
                part.UpdateItem(item);

            }
            
        }
        
    }
}