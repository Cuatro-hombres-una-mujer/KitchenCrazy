using UnityEngine;

namespace Food
{
    public class ItemFood
    {
        public string Name { get; set;  }
        public int Quantity { get; set; }
        
        public bool CanRequestedForClient { get; set; }

        public ItemFood(string name,int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
        
        public bool Equals(ItemFood itemFood)
        {
            return Name == itemFood.Name;
        }
    }
}