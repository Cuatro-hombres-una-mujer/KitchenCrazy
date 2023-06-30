using System;
using System.Collections;
using Entities.Player;
using UnityEngine;

namespace DefaultNamespace.Collision
{
    public class RecipeBookCollision : MonoBehaviour
    {

        private const string InventoryName = "recipe_inventory";
        private const string TagRecipeBook = "RecipeBook";
        private Player _player;
        [SerializeField] private GameObject recipeInventory;

        private void Start()
        {
            StartCoroutine(DelayStart());
        }

        private IEnumerator DelayStart()
        {
            yield return new WaitForSeconds(1f);
            _player = PlayerMovement.GetPlayer();
        }
        
        private void OnCollisionStay2D(Collision2D other)
        {
            if (Input.GetKey(KeyCode.Space) && other.gameObject.CompareTag(TagRecipeBook))
            {
                recipeInventory.SetActive(true);
                _player.OpenInventory(InventoryName);
                Debug.Log("Open inventory " + InventoryName);
            }   
            
        }
        
    }
    
}