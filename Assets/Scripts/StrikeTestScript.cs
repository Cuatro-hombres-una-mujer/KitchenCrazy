using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StrikeTestScript : MonoBehaviour
{
    public AudioSource clip;

    private void OnTriggerEnter2D(Collider2D other) {  
        if(other.gameObject.CompareTag("Player")) {
            GameManager.Instance.GainStrike();
            clip.Play();
            Debug.Log("INGRESA");
        }
    }
}
