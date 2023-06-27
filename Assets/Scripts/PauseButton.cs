using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject pauseScene;
    public void Pause() {
        pauseScene.SetActive(true);
        Debug.Log("Pausa");
    }

    public void Resume() {
        pauseScene.SetActive(false);
        Debug.Log("Reanudar");
    }
}
