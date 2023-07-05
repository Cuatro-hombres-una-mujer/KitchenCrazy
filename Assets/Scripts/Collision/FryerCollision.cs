using System.Collections;
using Entities.Player;
using Gui.Script;
using UnityEngine;

namespace DefaultNamespace.Collision
{
    public class FryerCollision : MonoBehaviour
    {
        
        [SerializeField] private GameObject inventoryFryer;
        private const string InventoryName = "Fryer_Inventory";
        private const string TagRecipeFryer = "Fryer";
        private Player _player;
        
        private void Start()
        {
            StartCoroutine(StartDelay());
        }

        private IEnumerator StartDelay()
        {
            yield return new WaitForSeconds(1f);
            _player = PlayerMovement.GetPlayer();
        }
        private void OnCollisionStay2D(Collision2D other)
        {
            if (Input.GetKey(KeyCode.Space) && other.gameObject.CompareTag(TagRecipeFryer))
            {
                inventoryFryer.SetActive(true);
                _player.OpenInventory(InventoryName);

                var fryerGuiHandler = FryerSystemScript.GetFryerGuiHandler();
                var inventoryHandler = fryerGuiHandler.GetInventoryGuiHandler();
                
                inventoryHandler.Refresh();
            }   
            
        }
        
    }
    
}