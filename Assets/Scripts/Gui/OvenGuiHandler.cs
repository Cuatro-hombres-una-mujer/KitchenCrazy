using System.Collections.Generic;
using Entities.Player;
using Food;

namespace DefaultNamespace.Gui
{
    public class OvenGuiHandler
    {
        private List<SlotOven> _slotOvens;

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