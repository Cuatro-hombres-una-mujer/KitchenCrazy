using System;
using System.Collections;
using Entities.Player;
using Food;
using UnityEngine;

namespace DefaultNamespace.Gui.Script
{
    public class KitchenColaGuiHandler : MonoBehaviour
    {

        private const string KitchenColaItemName = "KitchenCola";
        private const string InventoryName = "KitchenColaInventory";

        [SerializeField] private GameObject inventoryObject;
        
        private Player _player;
        private ItemFoodStorage _itemFoodStorage;
        private ItemFood _itemKitchenCola;

        private void Start()
        {
            StartCoroutine(StartDelay());
        }

        private IEnumerator StartDelay()
        {
            yield return new WaitForSeconds(1f);
            _player = PlayerMovement.GetPlayer();
            _itemFoodStorage = ItemFoodStorageScript.GetItemFoodStorage();

            _itemKitchenCola = _itemFoodStorage.Get(KitchenColaItemName);
        }

        public void OnClick()
        {

            var inventory = _player.Inventory;
            inventory.AddItem(_itemKitchenCola);

        }

        private void Update()
        {
            if (_player != null)
            {

                if (_player.HasOpenInventory() && _player.GetOpenedInventory() == InventoryName &&
                    Input.GetKeyDown(KeyCode.Escape))
                {
                    inventoryObject.SetActive(false);
                }
                
            }
            
        }
    }

}