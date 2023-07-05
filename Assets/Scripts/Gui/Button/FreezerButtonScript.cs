using System;
using System.Collections;
using Entities.Player;
using Food;
using UnityEngine;

namespace Button
{
    public class FreezerButtonScript : MonoBehaviour
    {

        private const string ItemName = "Kitchen-Cola";

        private Player _player;
        private ItemFoodStorage _itemFoodStorage;

        private void Start()
        {
            StartCoroutine(StartWithDelay());
        }

        private IEnumerator StartWithDelay()
        {
            yield return new WaitForSeconds(1F);
            _player = PlayerMovement.GetPlayer();
            _itemFoodStorage = ItemFoodStorageScript.GetItemFoodStorage();
        }

        public void GetKitchenCola()
        {
            var item = _itemFoodStorage.Get(ItemName);
            var inventory = _player.Inventory;
            
            inventory.AddItem(item);
        }
        
    }
    
}