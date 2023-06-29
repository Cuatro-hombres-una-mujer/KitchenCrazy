using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities.Player;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject pauseScene;
    private const string PauseName = "pause_escene";
    private Player _player;
    private bool _activePause;
    void Start()
    {
        _player = PlayerMovement.GetPlayer();
    }
    
    public void Pause() {
        Time.timeScale = 0f;
        pauseScene.SetActive(true);
        _player.OpenInventory(PauseName);
    }

    public void Resume() {
        Time.timeScale = 1f;
        pauseScene.SetActive(false);
        _player.CloseInventory();
    }
}