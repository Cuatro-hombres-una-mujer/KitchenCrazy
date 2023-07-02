using System;
using System.Collections;
using System.Collections.Generic;
using Food;
using UnityEngine;

namespace DefaultNamespace.Sprite
{
    public class SpriteStorageScript : MonoBehaviour
    {

        private SpriteStorage _spriteStorage;
        private ItemFoodStorage _itemFoodStorage;
        
        [SerializeField] private List<SpriteRenderer> _spriteRenderers;
        [SerializeField] private List<string> _names;


        public void Start()
        {
            StartCoroutine(StartWithDelay());
        }

        public IEnumerator StartWithDelay()
        {

            yield return new WaitForSeconds(3F);

            _spriteStorage = new SpriteStorage();
            _itemFoodStorage = ItemFoodStorageScript.GetItemFoodStorage();

            if (_spriteRenderers.Count != _names.Count)
            {
                throw new Exception("The list sprites renders and name should be same count");
            }

            for (var i = 0; i < _spriteRenderers.Count; i++)
            {

                var sprite = _spriteRenderers[i];
                var name = _names[i];
                
                _spriteStorage.Register(name, sprite);
                Debug.Log("Registered Sprite with name: " + name);

                if (_itemFoodStorage.Contains(name))
                {
                    Debug.Log("Registered as item");
                    var item = _itemFoodStorage.Get(name);
                    item.SpriteRenderer = sprite;
                }
                
            }
            
        }
        
        
        
    }
    
    
}