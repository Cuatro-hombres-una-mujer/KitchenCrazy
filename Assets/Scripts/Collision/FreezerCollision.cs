using System;
using System.Collections;
using Entities.Player;
using UnityEngine;

namespace DefaultNamespace.Collision
{
    public class FreezerCollision : MonoBehaviour
    {

        private const string InventoryName = "Freezer_Inventory";
        private const string Tag = "Freezer";
        private Player _player;
        
        [SerializeField] private GameObject freezerGameObjectInventory;

        public void Start()
        {
            StartCoroutine(StartWithDelay());
        }

        public IEnumerator StartWithDelay()
        {
            yield return new WaitForSeconds(1F);
            _player = PlayerMovement.GetPlayer();
        }

        private void Update()
        {

            if (_player == null)
            {
                return;
            }
            
            if (_player.HasOpenInventory() && _player.GetOpenedInventory() == InventoryName && 
                Input.GetKeyDown(KeyCode.Escape))
            {
                freezerGameObjectInventory.SetActive(false);
                _player.CloseInventory();
            }
            
        }

        public void OnCollisionStay2D(Collision2D other)
        {
            
            if (Input.GetKey(KeyCode.Space) && other.gameObject.CompareTag(Tag))
            {
                
                Debug.Log("Test Y");
                _player.OpenInventory(InventoryName);
                freezerGameObjectInventory.SetActive(true);
            }
            
        }
        
    }
    
}