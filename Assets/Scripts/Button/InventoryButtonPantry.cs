using System;
using Entities.Player;
using Food;
using UnityEngine;

namespace DefaultNamespace.Button
{
    public class InventoryButtonPantry : MonoBehaviour
    {
        [SerializeField] private GameObject canvasPantry;
        private Player _player;

        private ItemFoodStorage _itemFoodStorage;

        public void OnBack()
        {
            Console.WriteLine(":ON BACK");
            _player.CloseInventory();
            canvasPantry.SetActive(false);
        }

        public void OnClickAndGive(string name)
        {
            if (_player == null)
            {
                _player = PlayerMovement.GetPlayer();
            }

            if (_itemFoodStorage == null)
            {
                _itemFoodStorage = ItemFoodStorageScript.GetItemFoodStorage();
            }

            var inventory = _player.Inventory;
            var item = _itemFoodStorage.Get(name);

            inventory.AddItem(item);
        }
    }
}