using System.Collections;
using Entities.Player;
using UnityEngine;

namespace DefaultNamespace.Collision
{
    public class KitchenColaMachineCollision : MonoBehaviour
    {

        [SerializeField] private GameObject inventoryKitchenCola;
        private const string InventoryName = "recipe_inventory";
        private const string TagRecipeKitchenCola = "KitchenColaInventory";
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
            if (Input.GetKey(KeyCode.Space) && other.gameObject.CompareTag(TagRecipeKitchenCola))
            {
               inventoryKitchenCola.SetActive(true);
               _player.OpenInventory(InventoryName);
            }   
            
        }

    }
}