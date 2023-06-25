using UnityEngine;

namespace Food
{
    public class ItemFood
    {
        private string Name { get; }
        private int Quantity { get; }

        public ItemFood(string name,int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
        
        public bool Equals(ItemFood itemFood)
        {
            return Name == itemFood.Name;;
        }
    }
}