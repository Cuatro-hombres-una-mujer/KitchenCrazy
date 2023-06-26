using System;

namespace Entities.Player
{
    public class Player
    {
        private int _coins;
        public Inventory Inventory { get; }

        private string _inventoryOpened;

        public Player()
        {
            Inventory = new Inventory();
            _coins = 0;
        }

        public bool HasOpenInventory()
        {
            return _inventoryOpened != string.Empty;
        }

        public string GetOpenedInventory()
        {
            return _inventoryOpened;
        }

        public void OpenInventory(string inventoryName)
        {
            _inventoryOpened = inventoryName;
        }

        public void CloseInventory()
        {
            _inventoryOpened = string.Empty;
        }
        
        public bool IsView(string name)
        {
            return _inventoryOpened == name;
        }
        
        public int GetCoins()
        {
            return _coins;
        }

        public void SetCoins(int coins)
        {
            if (coins < 0)
            {
                return;
            }

            _coins = coins;
        }
    }
}