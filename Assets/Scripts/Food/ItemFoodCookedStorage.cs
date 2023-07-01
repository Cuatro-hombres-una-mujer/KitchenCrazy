using System.Collections.Generic;

namespace Food
{
    public class ItemFoodCookedStorage
    {

        private IDictionary<string, Preparation> _itemsCooked;

        public void Register(Preparation preparation)
        {
            var item = preparation.Item;
            
            _itemsCooked.Add(
                item.Name, preparation);
        }

        public Preparation Get(ItemFood item)
        {
            var name = item.Name;

            return _itemsCooked[name];
        }
        
    }
}