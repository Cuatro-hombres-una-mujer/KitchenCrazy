using System;
using UnityEngine;

namespace DefaultNamespace.Collision
{
    public class PantryCollision : MonoBehaviour
    {

        private const string Tag = "Pantry";
        private const string InventoryName = "Pantry_Inventory";
        [SerializeField] private GameObject canvasPantry;

        private void OnCollisionStay2D(Collision2D other)
        {
            var player = PlayerMovement.GetPlayer();
            
            if (other.gameObject.CompareTag(Tag) && Input.GetKey(KeyCode.Space))
            {
                canvasPantry.SetActive(true);
                player.OpenInventory(InventoryName);
            } 
            
        }
    }
}