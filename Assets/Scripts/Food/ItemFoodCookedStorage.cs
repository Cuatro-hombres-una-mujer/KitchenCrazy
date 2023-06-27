using System.Collections.Generic;

namespace Food
{
    public class ItemFoodCookedStorage
    {

        private IDictionary<string, ItemFoodCooked> _itemsCooked;

        public void Register(ItemFoodCooked itemFoodCooked)
        {
            var item = itemFoodCooked.Item;
            
            _itemsCooked.Add(
                item.Name, itemFoodCooked);
        }

        public ItemFoodCooked Get(ItemFood item)
        {
            var name = item.Name;

            return _itemsCooked[name];
        }
        
    }
}