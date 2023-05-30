using System;
using System.Collections.Generic;
using Skin;
using UnityEngine;

public class SkinUpdater : MonoBehaviour
{

    [SerializeField] private List<RuntimeAnimatorController> animators;
    
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private List<string> names;
    private void Start()
    {
        
        var spriteRenderer = GetComponent<SpriteRenderer>();
        var animator = GetComponent<Animator>();

        var skinHandler = new SkinHandler(
            spriteRenderer, animator, names, sprites, animators);

        
        
    }

}