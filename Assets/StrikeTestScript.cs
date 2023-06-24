using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeTestScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {  
        if(other.gameObject.CompareTag("Player")) {
            GameManager.Instance.GainStrike();
            Debug.Log("INGRESA");
        }
    }
}
