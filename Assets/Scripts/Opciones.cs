using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Opciones : MonoBehaviour
{   
    public AudioSource clip;

    [SerializeField] private AudioMixer audioMixer;

    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }
    public void CambiarVolumen(float Volumen)
    {
        audioMixer.SetFloat("Volumen", Volumen);
    }

    public void ButtonExit()
    {
        clip.Play();
        SceneManager.LoadScene(0);
    }

}
