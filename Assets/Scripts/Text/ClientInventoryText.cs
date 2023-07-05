using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace.Text
{
    public class ClientInventoryText
    {
        private readonly List<OrderPartInventoryText> _parts;
        private string _idClient;
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

        public void SetIdClient(string idClient)
        {
            _idClient = idClient;
        }
        
        public string GetClientName()
        {
            return _title.text;
        }

        public string GetClientId()
        {
            return _idClient;
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
        private readonly GameObject _checkGameObject;
        
        private bool _made;

        public OrderPartInventoryText(TextMeshProUGUI itemNameText, GameObject button,
            GameObject image, GameObject checkGameObject, bool made)
        {
            _itemNameText = itemNameText;
            _checkGameObject = checkGameObject;

            _image = image;
            _made = made;
            _button = button;
            
            checkGameObject.SetActive(_made);
        }

        public void Made()
        {
            _made = true;
            _checkGameObject.SetActive(true);
        }

        public void UnMade()
        {
            _made = false;
            _checkGameObject.SetActive(false);
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