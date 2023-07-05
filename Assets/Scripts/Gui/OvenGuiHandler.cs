using System.Collections.Generic;
using DefaultNamespace.Sprite;
using Entities.Player;
using Food;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Gui
{
    public class OvenGuiHandler
    {
        private const int Slots = 3;

        private readonly List<string> _itemsCanCooked;
        private readonly List<SlotOven> _slotOvens;
        private readonly InventoryGuiHandler _inventoryGuiHandler;
        
        private readonly GameObject _nextPageButton;
        private readonly GameObject _previousPageButton;

        public OvenGuiHandler(Inventory inventory, List<string> itemsCanCooked,
            GameObject nextPageButton, GameObject previousPageButton)
        {
            _slotOvens = new List<SlotOven>();

            _inventoryGuiHandler = new InventoryGuiHandler(inventory, Slots,
                nextPageButton, previousPageButton);
            _itemsCanCooked = itemsCanCooked;
        }

        public void AddSlotOven(SlotOven slotOven)
        {
            _slotOvens.Add(slotOven);
        }

        public List<SlotOven> GetSlots()
        {
            return _slotOvens;
        }

        public SlotOven GetSlot(int position)
        {
            return _slotOvens[position];
        }

        public bool HasSlotFree()
        {
            foreach (var slotOven in _slotOvens)
            {
                if (!slotOven.IsInPreCooking())
                {
                    return false;
                }
            }

            return true;
        }

        public SlotOven GetFreeSlotOven()
        {
            foreach (var slotOven in _slotOvens)
            {
                if (slotOven.IsInPreCooking())
                {
                    return slotOven;
                }
            }

            return null;
        }

        public void CookItemSelected(Player player)
        {

            var item = _inventoryGuiHandler.GetItemSelected();
            var name = item.Name;

            if (!_itemsCanCooked.Contains(name))
            {
                Debug.Log("No puedes cocinar este item");
                //Error warn it user!
                return;
            }

            Debug.Log("Cocinando este item food");
            var preparationStorage = PreparationStorageScript.GetPreparationStorage();
            var preparation = preparationStorage.Get(name);

            CookItemFood(preparation, player);
        }
        
        private void CookItemFood(Preparation preparation, Player player)
        {
            var freeSlotOven = GetFreeSlotOven();

            if (freeSlotOven == null)
            {
                //Warn it has not slot oven
                return;
            }
            
            var inventory = player.Inventory;
            inventory.DeleteItem(preparation.Item);
            
            _inventoryGuiHandler.Refresh();
            freeSlotOven.StartCook(preparation);
        }

        public InventoryGuiHandler GetInventoryGuiHandler()
        {
            return _inventoryGuiHandler;
        }
        
    }

    public class SlotOven
    {
        private CookState _cookState;
        private int _seconds;
        private Preparation _preparation;
        private ItemFood _itemCooked;
        private TextMeshProUGUI _buttonText;
        private Image _image;

        public SlotOven(TextMeshProUGUI buttonText, GameObject spriteImage)
        {
            _seconds = 0;
            _cookState = CookState.PreCooking;
            _buttonText = buttonText;
            
            _image = spriteImage.GetComponent<Image>();
            
            
            _buttonText.text = "Esperando alimento!";
        }

        public bool IsCooking()
        {
            return _cookState == CookState.Cooking;
        }

        public void StartCook(Preparation preparation)
        {
            _cookState = CookState.Cooking;
            _preparation = preparation;
            _itemCooked = _preparation.Item;
            _seconds = preparation.Seconds;

            var storageScript = SpriteStorageScript.GetSpriteStorage(SpriteType.Food);

            _image.sprite = storageScript.GetSprite(_itemCooked.Name);
            
            
            _buttonText.text = "Cocinando...";
        }

        public bool GetFoodPrepared(Player player)
        {
            if (_cookState != CookState.Ready)
            {
                return false;
            }

            var inventory = player.Inventory;
            var itemPrepared = _preparation.ItemCooked;
            _image.sprite = null;
            
            inventory.AddItem(itemPrepared);
            _seconds = 0;
            _buttonText.text = "Esperando alimento!";
            Empty();
            return true;
        }

        private void Empty()
        {
            _cookState = CookState.PreCooking;
            _seconds = 0;
            _preparation = null;
        }

        public void OnFinishCook()
        {
            _itemCooked = _preparation.ItemCooked;
            _cookState = CookState.Ready;
            _image.sprite = _itemCooked.Sprite;
            
            var storageScript = SpriteStorageScript.GetSpriteStorage(SpriteType.Food);
            _image.sprite = storageScript.GetSprite(_itemCooked.Name);
            
            _buttonText.text = "Cocinado!";
        }


        public bool IsInPreCooking()
        {
            return _cookState == CookState.PreCooking;
        }

        public void OnUpdate()
        {
            if (!IsCooking())
            {
                return;   
            }
            
            _seconds--;

            if (_seconds == 0)
            {
                OnFinishCook();
            }
        }
    }

    enum CookState
    {
        PreCooking,
        Cooking,
        Ready
    }
}