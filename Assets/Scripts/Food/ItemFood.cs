using UnityEngine;

namespace Food
{
    public class ItemFood
    {
        public string Name { get; set;  }
        public int Quantity { get; set; }
        
        public SpriteRenderer SpriteRenderer { get; set; }
        
        public bool RequestedForClient { get; set; }

        public ItemFood(string name,int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public bool Equals(ItemFood itemFood)
        {
            return Name == itemFood.Name;
        }

        public bool IsUnique()
        {
            return Quantity == 1;
        }

        public void Remove(int quantity)
        {
            Quantity = Quantity - quantity;

            if (Quantity < 0)
            {
                Quantity = 0;
            }
        }
        
    }
}