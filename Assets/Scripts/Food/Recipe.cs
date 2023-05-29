using System.Collections.Generic;

namespace Food
{
    public class Recipe
    {
        private List<ItemFood> _items;
        private ItemFood _itemFood;
        
        public Recipe(List<ItemFood> _items)
        {
            this._items = _items;
        }

        public bool HasElements(InventoryHandler inventoryHandler)
        {
            return false;
        }
        
        
    }
}