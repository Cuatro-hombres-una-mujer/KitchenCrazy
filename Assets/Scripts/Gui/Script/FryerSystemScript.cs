using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Gui;
using Entities.Player;
using TMPro;
using UnityEngine;

namespace Gui.Script
{
    public class FryerSystemScript : MonoBehaviour
    {
        private int _nextUpdate = 1;
        private const string InventoryName = "Fryer_Inventory";
        private static OvenGuiHandler _fryerGuiHandler;
        private Player _player;
        private InventoryGuiHandler _inventoryGuiHandler;

        [SerializeField] private GameObject ovenInventoryGameObject;
        
        [Header("Kitchen")]
        [SerializeField] private List<string> itemsCanCooked;
        [SerializeField] private TextMeshProUGUI firstButtonOvenText;
        [SerializeField] private TextMeshProUGUI secondButtonOvenText;

        
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
            _fryerGuiHandler = new OvenGuiHandler(_player.Inventory, itemsCanCooked, nextInventoryButton
            ,previousInventoryButton);
            
            _fryerGuiHandler.AddSlotOven(new SlotOven(firstButtonOvenText));
            _fryerGuiHandler.AddSlotOven(new SlotOven(secondButtonOvenText));

            var inventoryHandler = _fryerGuiHandler.GetInventoryGuiHandler();

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

        public static OvenGuiHandler GetFryerGuiHandler()
        {
            return _fryerGuiHandler;
        }

        public void GetFoodCookedOnClickButton(int position)
        {
            var slotOven = _fryerGuiHandler.GetSlot(position); 
            slotOven.GetFoodPrepared(_player);
        }

        private void RefreshItemsForCook()
        {
            foreach (var slotOven in _fryerGuiHandler.GetSlots())
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
            _fryerGuiHandler.CookItemSelected(_player);
        }

        public void OnClickButtonInKitchen(int position)
        {
            var slot = _fryerGuiHandler.GetSlot(position);
            var reply = slot.GetFoodPrepared(_player);

            if (reply)
            {
                _inventoryGuiHandler.Refresh();
            }
            
        }
        
        
    }
}