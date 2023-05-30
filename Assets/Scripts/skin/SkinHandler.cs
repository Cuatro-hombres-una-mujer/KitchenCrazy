using System.Collections.Generic;
using UnityEngine;

namespace Skin
{
    public class SkinHandler
    {
        private readonly SpriteRenderer _spriteRenderer;
        private readonly Animator _animator;

        private readonly List<string> _names;
        private readonly List<Sprite> _sprites;
        private readonly List<RuntimeAnimatorController> _runtimeAnimatorControllers;

        public SkinHandler(SpriteRenderer spriteRenderer, Animator animator,
            List<string> names, List<Sprite> sprites, List<RuntimeAnimatorController> runtimeAnimatorControllers)
        {
            _names = names;
            _sprites = sprites;

            _spriteRenderer = spriteRenderer;
            _animator = animator;
            _runtimeAnimatorControllers = runtimeAnimatorControllers;
        }

        public void Update(string name)
        {
            if (!_names.Contains(name))
            {
                return;
            }
            
            var index = _names.IndexOf(name);
            var sprite = GetSprite(index);
            var runTimeAnimatorController = GetRuntimeAnimatorController(index);

            _spriteRenderer.sprite = sprite;
            _animator.runtimeAnimatorController = runTimeAnimatorController;

        }

        public Sprite GetSprite(int index)
        {
            return _sprites[index];
        }

        public RuntimeAnimatorController GetRuntimeAnimatorController(int index)
        {
            return _runtimeAnimatorControllers[index];
        }

    }
    
}