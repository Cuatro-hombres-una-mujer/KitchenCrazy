using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CookerMenu : MonoBehaviour
{

    private bool cookEnabled;

    public GameObject kitchen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        
        {
            cookEnabled = !cookEnabled;
        }
        if (cookEnabled == true)
        {
            kitchen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            kitchen.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void BackToGame(){
        cookEnabled = !cookEnabled;
        kitchen.SetActive(false);
        Time.timeScale = 1f;
    }
}
