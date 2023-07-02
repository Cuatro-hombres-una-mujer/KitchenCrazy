using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Sprite
{
    public class SpriteStorage
    {

        private readonly IDictionary<string, SpriteRenderer> _sprites;

        public SpriteStorage()
        {
            _sprites = new Dictionary<string, SpriteRenderer>();
        }

        public void Register(string name, SpriteRenderer spriteRenderer)
        {
            _sprites[name] = spriteRenderer;
        }

        public SpriteRenderer GetSprite(string name)
        {
            return _sprites[name];
        }

    }
    
}