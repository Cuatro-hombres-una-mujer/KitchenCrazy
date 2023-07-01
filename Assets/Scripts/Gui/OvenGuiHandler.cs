using System.Collections.Generic;
using Entities.Player;
using Food;

namespace DefaultNamespace.Gui
{
    public class OvenGuiHandler
    {
        private readonly List<SlotOven> _slotOvens;

        public OvenGuiHandler()
        {
            _slotOvens = new List<SlotOven>();
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
                if (!slotOven.IsInPreCooking())
                {
                    return slotOven;
                }
            }

            return null;
        }

        public void CookItemFood(Preparation preparation)
        {
            var freeSlotOven = GetFreeSlotOven();

            if (freeSlotOven == null)
            {
                //Warn it has not slot oven
                return;
            }
            
            freeSlotOven.StartCook(preparation);
        }
        
    }

    public class SlotOven
    {
        
        private CookState _cookState;
        private int _seconds;
        private Preparation _preparation;
        private ItemFood _itemCooked;

        public SlotOven()
        {
            _seconds = 0;
            _cookState = CookState.PreCooking;
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
        }

        public void GetFoodPrepared(Player player)
        {
            if (_cookState != CookState.Ready)
            {
                return;
            }

            var inventory = player.Inventory;
            var itemPrepared = _preparation.ItemCooked;
            
            inventory.AddItem(itemPrepared);
            Empty();

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
        }

        
        public bool IsInPreCooking()
        {
            return _cookState == CookState.PreCooking;
        }
        
        public void OnUpdate()
        {
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