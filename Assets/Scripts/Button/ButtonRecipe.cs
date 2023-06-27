using System;
using Entities.Player;
using UnityEngine;

namespace Food
{
    public class ButtonRecipe : MonoBehaviour
    {

        private Player _player;

        private void Awake()
        {
            _player = PlayerMovement.GetPlayer();
        }

        public void CookAtRecipe(string name)
        {
            
            
            
        }
        
    }
    
}