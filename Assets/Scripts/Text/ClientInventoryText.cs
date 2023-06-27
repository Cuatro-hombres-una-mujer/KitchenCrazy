using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

namespace DefaultNamespace.Text
{
    public class ClientInventoryText
    {
        private readonly List<OrderPartInventoryText> _parts;
        private readonly TextMeshProUGUI _title;

        public ClientInventoryText(TextMeshProUGUI title)
        {
            _title = title;
            _parts = new List<OrderPartInventoryText>();
        }

        public void SetTitle(string titleValue)
        {

            if (_title.text == titleValue)
            {
                return;
            }
            
            _title.text = titleValue;
        }
        
        public void AddPart(OrderPartInventoryText orderPartInventoryText)
        {
            _parts.Add(orderPartInventoryText);
        }

        public OrderPartInventoryText GetPart(int position)
        {
            return _parts[position];
        }
        
    }

    public class OrderPartInventoryText
    {
        private readonly TextMeshProUGUI _itemNameText;
        private bool _made;

        public OrderPartInventoryText(TextMeshProUGUI itemNameText, bool made)
        {
            _itemNameText = itemNameText;
            _made = made;
        }

        public void Made(bool made)
        {
            _made = made;
        }

        public void UpdateText(string itemNameTextValue)
        {
            if (_itemNameText.text != itemNameTextValue)
            {
                _itemNameText.text = itemNameTextValue;
            }
        }
    }
}