using System.Collections.Generic;

namespace Food
{
    public class Recipe
    {
        private List<string> Items { get; set; }
        public ItemFood ItemFood { get; set; }

        public Recipe(List<string> items, ItemFood itemFood)
        {
            Items = items;
            ItemFood = itemFood;
            
        }

        public bool HasElements(Inventory inventoryHandler)
        {
            /*
            foreach (var item in Items)
            {
                if (!inventoryHandler.HasElementOrSuperior(item))
                {
                    return false;
                }
            }*/

            return true;
        }

        public void Cook(Inventory inventoryHandler)
        {
            DeleteItems(inventoryHandler);
            inventoryHandler.AddItem(ItemFood);
        }

        private void DeleteItems(Inventory inventoryHandler)
        {

            foreach (var item in Items)
            {
                //inventoryHandler.DeleteItem(item);
            }
         
        }

    }
}