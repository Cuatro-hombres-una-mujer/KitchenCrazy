using System;
using System.Collections;
using Entities.Player;
using UnityEngine;

namespace DefaultNamespace.Gui
{
    public class DespenseGuiScript : MonoBehaviour
    {

        private const string InventoryName = "Pantry_Inventory";
            
        [SerializeField] private GameObject despenseGameObjectPageOne;
        [SerializeField] private GameObject despenseGameObjectTwo;

        private Player _player;

        private void Start()
        {
            Debug.Log("Despense Gui Script");
            StartCoroutine(StartWithDelay());
        }

        public IEnumerator StartWithDelay()
        {
            yield return new WaitForSeconds(2F);
            _player = PlayerMovement.GetPlayer();
        }

        private void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.Escape) && _player.HasOpenInventory() &&
                _player.GetOpenedInventory() == InventoryName)
            {
                _player.CloseInventory();
                despenseGameObjectPageOne.SetActive(false);
                despenseGameObjectTwo.SetActive(false);
            }
            
        }
        
    }
    
}