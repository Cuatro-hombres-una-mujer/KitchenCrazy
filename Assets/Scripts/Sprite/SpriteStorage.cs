using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Sprite
{
    public class SpriteStorage
    {

        private readonly IDictionary<string, UnityEngine.Sprite> _sprites;

        public SpriteStorage()
        {
            _sprites = new Dictionary<string, UnityEngine.Sprite>();
        }

        public void Register(string name, UnityEngine.Sprite sprite)
        {
            _sprites[name] = sprite;
        }

        public UnityEngine.Sprite GetSprite(string name)
        {
            return _sprites[name];
        }

        public void PrintValues()
        {
            
            Debug.Log("KEYS: ");
            
            foreach (var spritesKey in _sprites.Keys)
            {
                Debug.Log(spritesKey);
            }
            
            Debug.Log("----------");
            
        }
        
    }
    
}