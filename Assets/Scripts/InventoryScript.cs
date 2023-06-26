using System;
using Entities.Player;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class InventoryScript : MonoBehaviour
    {
        [SerializeField] private GameObject inventoryObject;
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;

        private const string InventoryName = "player_inventory";
        private Player _player;

        private void Awake()
        {
            _player = PlayerMovement.GetPlayer();
        }

        private void Update()
        {

            if (_player == null)
            {
                _player = PlayerMovement.GetPlayer();
            }
            
            if (!_player.IsView(InventoryName) && Input.GetKey(KeyCode.E))
            {
                inventoryObject.SetActive(true);
                _player.OpenInventory(InventoryName);

                var inventory = _player.Inventory;
                textMeshProUGUI.text = inventory.GetItemsInString();
            }

            if (_player.IsView(InventoryName) && Input.GetKey(KeyCode.Escape))
            {
                inventoryObject.SetActive(false);
                _player.CloseInventory();
            }
            
        }
    }
}