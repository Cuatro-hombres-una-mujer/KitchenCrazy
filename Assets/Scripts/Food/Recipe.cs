using System.Collections.Generic;

namespace Food
{
    public class Recipe
    {
        public List<ItemFood> Items { get; set; }
        public ItemFood ItemFood { get; set; }

        public Recipe(List<ItemFood> items, ItemFood itemFood)
        {
            Items = items;
            ItemFood = itemFood;
            
        }

        public bool HasElements(InventoryHandler inventoryHandler)
        {
            foreach (var item in Items)
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
            inventoryHandler.AddItem(ItemFood);
        }

        private void DeleteItems(InventoryHandler inventoryHandler)
        {

            foreach (var item in Items)
            {
                inventoryHandler.DeleteItem(item);
            }
         
        }

    }
}