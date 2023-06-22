using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioSource clip;
    public void Play()
    {
        SceneManager.LoadScene(1);
        clip.Play();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        clip.Play();
    }

    public void Option()
    {
        SceneManager.LoadScene(3);
        clip.Play();
    }
    
    public void Shop()
    {
        SceneManager.LoadScene(4);
        clip.Play();
    }

    public void Exit()
    {
        Debug.Log("Salir...");
        Application.Quit();
        clip.Play();
    }
}
