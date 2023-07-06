using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameOverOrdersScript : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI textOrders;
        private const string Prefix = "Tus pedidos son: ";

        private const string KeyOrders = "Orders";
        
        private void Awake()
        {

            var value = PlayerPrefs.GetInt(KeyOrders);
            var contentFinal = Prefix + value;

            textOrders.text = contentFinal;

        }
        
    }
}