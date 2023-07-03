using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Gui;
using Entities.Player;
using TMPro;
using UnityEngine;

namespace Gui.Script
{
    public class OvenGuiHandlerScript : MonoBehaviour
    {

        private int _nextUpdate = 1;
        private const string InventoryName = "Oven_Inventory";
        private static OvenGuiHandler _ovenGuiHandler;
        private Player _player;
        private InventoryGuiHandler _inventoryGuiHandler;

        [SerializeField] private GameObject ovenInventoryGameObject;
        
        [Header("Kitchen")]
        [SerializeField] private List<string> itemsCanCooked;
        [SerializeField] private TextMeshProUGUI firstButtonOvenText;
        [SerializeField] private TextMeshProUGUI secondButtonOvenText;
        [SerializeField] private TextMeshProUGUI thirdButtonOvenText;

        
        [Header("Inventory Slot One")]
        [SerializeField] private TextMeshProUGUI contentTextOne;
        [SerializeField] private GameObject arrowOne;

        [Header("Inventory Slot Two")]
        [SerializeField] private TextMeshProUGUI contentTextTwo;
        [SerializeField] private GameObject arrowTwo;

        [Header("Inventory Slot Third")]
        [SerializeField] private TextMeshProUGUI contentTextThird;
        [SerializeField] private GameObject arrowThird;

        [Header("Inventory Slot Four")]
        [SerializeField] private TextMeshProUGUI contentTextFour;
        [SerializeField] private GameObject arrowFour;

        [Header("Button Inventory")]
        [SerializeField] private GameObject nextInventoryButton;
        [SerializeField] private GameObject previousInventoryButton;
        
        private void Awake()
        {
            StartCoroutine(StartWithDelay());
        }

        private IEnumerator StartWithDelay()
        {

            yield return new WaitForSeconds(1F);
            
            _player = PlayerMovement.GetPlayer();
            _ovenGuiHandler = new OvenGuiHandler(_player.Inventory, itemsCanCooked, nextInventoryButton
            ,previousInventoryButton);
            
            _ovenGuiHandler.AddSlotOven(new SlotOven(firstButtonOvenText));
            _ovenGuiHandler.AddSlotOven(new SlotOven(secondButtonOvenText));
            _ovenGuiHandler.AddSlotOven(new SlotOven(thirdButtonOvenText));

            var inventoryHandler = _ovenGuiHandler.GetInventoryGuiHandler();

            inventoryHandler.AddPart(new PartInventoryGuiHandler(contentTextOne, arrowOne));
            inventoryHandler.AddPart(new PartInventoryGuiHandler(contentTextTwo, arrowTwo));
            inventoryHandler.AddPart(new PartInventoryGuiHandler(contentTextThird, arrowThird));
            inventoryHandler.AddPart(new PartInventoryGuiHandler(contentTextFour, arrowFour));

            _inventoryGuiHandler = inventoryHandler;
        }

        private void Update()
        {

            if (_player == null)
            {
                return;
            }

            OnInputEvent();
            
            if(Time.time >= _nextUpdate){
                _nextUpdate= Mathf.FloorToInt(Time.time) + 1;
                RefreshItemsForCook();
            }
        
            
        }

        private void OnInputEvent()
        {
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

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    ovenInventoryGameObject.SetActive(false);
                    _player.CloseInventory();
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    PressEnter();
                }

            }
        }

        public static OvenGuiHandler GetOvenGuiHandler()
        {
            return _ovenGuiHandler;
        }

        public void GetFoodCookedOnClickButton(int position)
        {
            var slotOven = _ovenGuiHandler.GetSlot(position); 
            slotOven.GetFoodPrepared(_player);
        }

        private void RefreshItemsForCook()
        {
            foreach (var slotOven in _ovenGuiHandler.GetSlots())
            {
                slotOven.OnUpdate();   
            }
        }

        public void NextPageInventoryButtonOnClicked()
        {
            _inventoryGuiHandler.NextPage();
        }

        public void PreviousPageInventoryButtonOnClicked()
        {
            _inventoryGuiHandler.PreviousPage();
        }
        
        private void PressEnter()
        {
            _ovenGuiHandler.CookItemSelected(_player);
        }

        public void OnClickButtonInKitchen(int position)
        {
            var slot = _ovenGuiHandler.GetSlot(position);
            var reply = slot.GetFoodPrepared(_player);

            if (reply)
            {
                _inventoryGuiHandler.Refresh();
            }
            
        }
        
    }
}