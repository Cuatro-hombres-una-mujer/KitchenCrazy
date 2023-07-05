using System;
using DefaultNamespace.Text;
using TMPro;
using UnityEngine;

namespace Entities
{
    public class ClientInventoryScript : MonoBehaviour
    {
        
        [SerializeField] private TextMeshProUGUI title;

        [Header("Text")]
        [SerializeField] private TextMeshProUGUI partOneFood;
        [SerializeField] private TextMeshProUGUI partTwoFood;
        [SerializeField] private TextMeshProUGUI partThirdFood;
        [SerializeField] private TextMeshProUGUI partFourFood;

        [Header("Button")] 
        [SerializeField] private GameObject partOneButton;
        [SerializeField] private GameObject partTwoButton;
        [SerializeField] private GameObject partThirdButton;
        [SerializeField] private GameObject partFourButton;

        [Header("Image")] 
        [SerializeField] private GameObject partOneImage;
        [SerializeField] private GameObject partTwoImage;
        [SerializeField] private GameObject partThirdImage;
        [SerializeField] private GameObject partFourImage;

        [Header("Check")] 
        [SerializeField] private GameObject partOneCheck;
        [SerializeField] private GameObject partTwoCheck;
        [SerializeField] private GameObject partThirdCheck;
        [SerializeField] private GameObject partFourCheck;
        
        private static ClientInventoryText _clientInventoryText;
        
        private void Awake()
        {
            _clientInventoryText = new ClientInventoryText(title);
            
            _clientInventoryText.AddPart(new OrderPartInventoryText(partOneFood, partOneButton, partOneImage, partOneCheck, false));
            _clientInventoryText.AddPart(new OrderPartInventoryText(partTwoFood, partTwoButton, partTwoImage, partTwoCheck, false));
            _clientInventoryText.AddPart(new OrderPartInventoryText(partThirdFood,partThirdButton, partThirdImage, partThirdCheck, false));
            _clientInventoryText.AddPart(new OrderPartInventoryText(partFourFood, partFourButton, partFourImage, partFourCheck, false));
            
        }

        public static ClientInventoryText GetClientInventoryText()
        {
            return _clientInventoryText;
        }
        
    }
}