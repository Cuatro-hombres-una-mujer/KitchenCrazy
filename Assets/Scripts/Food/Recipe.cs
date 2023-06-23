using System.Collections.Generic;

namespace Food
{
    public class Recipe
    {
        private readonly List<ItemFood> _items;
        private ItemFood _itemFood;

        public Recipe(List<ItemFood> items)
        {
            _items = items;
        }

        public bool HasElements(InventoryHandler inventoryHandler)
        {
            foreach (var item in _items)
            {
                if (!inventoryHandler.HasElementOrSuperior(item))
                {
                    return false;
                }
            }

            return true;
        }

        public void CreateFood(InventoryHandler inventoryHandler)
        {
            DeleteItems(inventoryHandler);
            inventoryHandler.AddItem(_itemFood);
        }

        private void DeleteItems(InventoryHandler inventoryHandler)
        {

            foreach (var item in _items)
            {
                inventoryHandler.DeleteItem(item);
            }
         
        }

    }
}