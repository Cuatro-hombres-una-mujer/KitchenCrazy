using System;
using DefaultNamespace.Text;
using TMPro;
using UnityEngine;

namespace Entities
{
    public class ClientInventoryScript : MonoBehaviour
    {
        
        [SerializeField] private TextMeshProUGUI title;

        [SerializeField] private TextMeshProUGUI partOneFood;
        [SerializeField] private TextMeshProUGUI partTwoFood;
        [SerializeField] private TextMeshProUGUI partThirdFood;

        private static ClientInventoryText _clientInventoryText;
        
        private void Awake()
        {
            _clientInventoryText = new ClientInventoryText(title);
            
            _clientInventoryText.AddPart(new OrderPartInventoryText(partOneFood, false));
            _clientInventoryText.AddPart(new OrderPartInventoryText(partTwoFood, false));
            _clientInventoryText.AddPart(new OrderPartInventoryText(partThirdFood, false));
        }

        public static ClientInventoryText GetClientInventoryText()
        {
            return _clientInventoryText;
        }
        
    }
}