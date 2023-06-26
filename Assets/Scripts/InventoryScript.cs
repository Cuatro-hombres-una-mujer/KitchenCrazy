using System;
using Entities.Player;
using UnityEngine;

namespace DefaultNamespace
{
    public class InventoryScript : MonoBehaviour
    {
        [SerializeField] private GameObject inventoryObject;

        private const string InventoryName = "player_inventory";
        private Player _player;

        private void Awake()
        {
            _player = PlayerMovement.GetPlayer();
        }

        private void Update()
        {
            if (!_player.IsView(InventoryName) && Input.GetKey(KeyCode.E))
            {
                inventoryObject.SetActive(true);
                _player.OpenInventory(InventoryName);
            }

            if (_player.IsView(InventoryName) && Input.GetKey(KeyCode.Escape))
            {
                inventoryObject.SetActive(false);
                _player.CloseInventory();
            }
            
        }
    }
}