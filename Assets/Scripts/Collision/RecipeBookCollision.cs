using System;
using UnityEngine;

namespace DefaultNamespace.Collision
{
    public class RecipeBookCollision : MonoBehaviour
    {

        private const string TagRecipeBook = "Recipe Book";
        
        
        [SerializeField] private GameObject recipeInventory;
         private void OnCollisionStay2D(Collision2D other)
        {
            if (Input.GetKey(KeyCode.Space) && other.gameObject.CompareTag(TagRecipeBook))
            {
                recipeInventory.SetActive(true);
            }   
            
        }
        
    }
    
}