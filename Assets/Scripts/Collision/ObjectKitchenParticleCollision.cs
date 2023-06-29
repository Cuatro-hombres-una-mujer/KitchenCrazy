using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Collision
{
    public class ObjectKitchenParticleCollision : MonoBehaviour
    {
        [SerializeField] private GameObject ovenParticleObject;
        [SerializeField] private GameObject fryerParticleObject;
        [SerializeField] private GameObject chimneyParticleObject;
        [SerializeField] private GameObject fridgeParticleObject;

        private IDictionary<string, GameObject> _particles;

        private void Start()
        {
            _particles = new Dictionary<string, GameObject>();

            _particles.Add("Oven", ovenParticleObject);
            _particles.Add("Fryer", fryerParticleObject);
            _particles.Add("Chimney", chimneyParticleObject);
            _particles.Add("Fridge", fridgeParticleObject);
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            
            print("AAAAAR");
            
            if (Input.GetKey(KeyCode.Space))
            {

                var tag = other.gameObject.tag;
                Debug.Log("Tag: " + tag);    
                
                var particle = _particles[tag];
                
                Debug.Log("Tag: " + tag);
                
                particle.SetActive(true);
                Debug.Log("PARTICLE ACTIVED!!!");        
            }
        }
    }
}