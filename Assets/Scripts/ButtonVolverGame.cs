using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ButtonVolverGame : MonoBehaviour
{   
    public AudioSource clip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Volver()
    {
        SceneManager.LoadScene(1);
        clip.Play();
    }
}
