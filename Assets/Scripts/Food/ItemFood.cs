using UnityEngine;

namespace Food
{
    public class ItemFood
    {
        private readonly string _name;
        private readonly Sprite _sprite;
        private int _quantity;

        public ItemFood(string name, Sprite sprite, int quantity)
        {
            _name = name;
            _sprite = sprite;
            _quantity = quantity;
        }

        public string GetName()
        {
            return this._name;
        }

        public Sprite GetSprite()
        {
            return this._sprite;
        }

        public int GetQuantity()
        {
            return this._quantity;
        }

        public void SetQuantity(int quantity)
        {
            _quantity = quantity;
        }

        public bool Equals(ItemFood itemFood)
        {
            return itemFood.GetName() == GetName();
        }
    }
}