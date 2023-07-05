using System;
using System.Collections;
using System.Collections.Generic;
using Entities;
using Food;
using UnityEngine;

namespace DefaultNamespace.Sprite
{
    public class SpriteStorageScript : MonoBehaviour
    {

        private static IDictionary<SpriteType, SpriteStorage> _storages;
        private ItemFoodStorage _itemFoodStorage;
        
        [SerializeField] private List<UnityEngine.Sprite> spriteRenderersFood;
        [SerializeField] private List<string> namesFood;

        [SerializeField] private List<UnityEngine.Sprite> spriteRendersClient;
        [SerializeField] private List<string> clientNames;

        public void Start()
        {
            StartCoroutine(StartWithDelay());
        }

        public IEnumerator StartWithDelay()
        {

            yield return new WaitForSeconds(3F);
            _storages = new Dictionary<SpriteType, SpriteStorage>();
            LoadSpriteStorageFood();
            LoadClientSprites();

        }

        public void LoadClientSprites()
        {

            var spriteClientStorage = new SpriteStorage();

            for (var i = 0; i < spriteRendersClient.Count; i++)
            {

                var sprite = spriteRendersClient[i];
                var name = clientNames[i];
                
                spriteClientStorage.Register(name, sprite);
            }

            _storages[SpriteType.Client] = spriteClientStorage;
        }
        
        public void LoadSpriteStorageFood()
        {
            var spriteStorage = new SpriteStorage();
            _itemFoodStorage = ItemFoodStorageScript.GetItemFoodStorage();

            if (spriteRenderersFood.Count != namesFood.Count)
            {
                throw new Exception("The list sprites renders and name should be same count");
            }

            for (var i = 0; i < spriteRenderersFood.Count; i++)
            {

                var sprite = spriteRenderersFood[i];
                var name = namesFood[i];
                
                Debug.Log("[A] Registered: " + name);
                spriteStorage.Register(name, sprite);
                

                if (_itemFoodStorage.Contains(name))
                {
                    Debug.Log("Registered as item: " + name);
                    var item = _itemFoodStorage.Get(name);
                    item.Sprite = sprite;
                }
                
            }

            _storages[SpriteType.Food] = spriteStorage;
        }

        public static SpriteStorage GetSpriteStorage(SpriteType type)
        {
            return _storages[type];
        }
        
    }

    public enum SpriteType
    {
        Food, Client
    }
    
}