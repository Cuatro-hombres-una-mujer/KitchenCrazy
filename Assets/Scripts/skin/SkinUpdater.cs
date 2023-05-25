using System;
using System.Collections.Generic;
using Skin;
using UnityEngine;

public class SkinUpdater : MonoBehaviour
{

    [SerializeField] private List<RuntimeAnimatorController> _animators;
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private List<string> _names;
    private void Start()
    {
        
        var _spriteRenderer = GetComponent<SpriteRenderer>();
        var _animator = GetComponent<Animator>();

        var skinHandler = new SkinHandler(
            _spriteRenderer, _animator, _names, _sprites, _animators);

    }

}