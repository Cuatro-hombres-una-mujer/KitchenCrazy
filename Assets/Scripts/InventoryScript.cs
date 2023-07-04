using System;
using System.Collections;
using DefaultNamespace.Gui;
using Entities.Player;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class InventoryScript : MonoBehaviour
    {
        
        [SerializeField] private GameObject inventoryObject;

        [Header("Text")] 
        [SerializeField] private TextMeshProUGUI firstComponentTextGui;
        [SerializeField] private TextMeshProUGUI secondComponentTextGui;
        [SerializeField] private TextMeshProUGUI thirdComponentTextGui;
        [SerializeField] private TextMeshProUGUI fourComponentTextGui;
        [SerializeField] private TextMeshProUGUI fiveComponentTextGui;
        
        [Header("Indicator")]
        [SerializeField] private GameObject firstComponentButtonGui;
        [SerializeField] private GameObject secondComponentButtonGui;
        [SerializeField] private GameObject thirdComponentButtonGui;
        [SerializeField] private GameObject fourComponentButtonGui;
        [SerializeField] private GameObject fiveComponentButtonGui;
        
        private InventoryGuiPlayerHandler _inventoryGuiHandler;
        
        private const string InventoryName = "player_inventory";
        private Player _player;

        private void Start()
        {
            StartCoroutine(StartWithDelay());
        }

        private IEnumerator StartWithDelay()
        {
            yield return new WaitForSeconds(1F);
            _player = PlayerMovement.GetPlayer();
            _inventoryGuiHandler = new InventoryGuiPlayerHandler(_player.Inventory);
            
            _inventoryGuiHandler.AddPart(
                new PartInventoryGuiHandler(firstComponentTextGui, firstComponentButtonGui));
            
            _inventoryGuiHandler.AddPart(
                new PartInventoryGuiHandler(secondComponentTextGui, secondComponentButtonGui));
            
            _inventoryGuiHandler.AddPart(
                new PartInventoryGuiHandler(thirdComponentTextGui, thirdComponentButtonGui));
            
            _inventoryGuiHandler.AddPart(
                new PartInventoryGuiHandler(fourComponentTextGui, fourComponentButtonGui));
            
            _inventoryGuiHandler.AddPart(
                new PartInventoryGuiHandler(fiveComponentTextGui, fiveComponentButtonGui));
            
        }

        private void Update()
        {

            if (_player == null)
            {
                return;
            }
            
            if (!_player.HasOpenInventory() && Input.GetKey(KeyCode.E))
            {
                inventoryObject.SetActive(true);
                _player.OpenInventory(InventoryName);
                _inventoryGuiHandler.Open(_player.Inventory);

                _inventoryGuiHandler.Refresh();
                
            }

            if (_player.IsView(InventoryName) && Input.GetKey(KeyCode.Escape))
            {
                inventoryObject.SetActive(false);
                _inventoryGuiHandler.Close();
                _player.CloseInventory();
            }

            if (_player.HasOpenInventory() && _player.GetOpenedInventory() == InventoryName)
            {
                
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    _inventoryGuiHandler.Down();
                }

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    _inventoryGuiHandler.Up();
                }
                
            }
            
        }
    }
}