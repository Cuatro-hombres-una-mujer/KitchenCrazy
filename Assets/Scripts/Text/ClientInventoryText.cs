using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

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

        public string GetClientName()
        {
            return _title.text;
        }

        public void AddPart(OrderPartInventoryText orderPartInventoryText)
        {
            _parts.Add(orderPartInventoryText);
        }

        public OrderPartInventoryText GetPart(int position)
        {
            return _parts[position];
        }

        public List<OrderPartInventoryText> GetParts()
        {
            return _parts;
        }

    }

    public class OrderPartInventoryText
    {
        private readonly TextMeshProUGUI _itemNameText;
        private readonly GameObject _button;
        private readonly GameObject _image;
        private bool _made;

        public OrderPartInventoryText(TextMeshProUGUI itemNameText, GameObject button, 
            GameObject image, bool made)
        {
            _itemNameText = itemNameText;

            _image = image;
            _made = made;
            _button = button;
        }

        public void Made()
        {
            _made = true;
        }

        public GameObject GetButton()
        {
            return _button;
        }

        public GameObject GetImageObject()
        {
            return _image;
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