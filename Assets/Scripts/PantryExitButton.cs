using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities.Player;

public class PantryExitButton : MonoBehaviour
{
    private void Awake()
    {
        _player = PlayerMovement.GetPlayer();
    }
    private Player _player;
    [SerializeField] private GameObject pauseScene;
    public void Pause() {
        pauseScene.SetActive(true);
    }

    public void Resume() {
        pauseScene.SetActive(false);
        _player.CloseInventory();
    }
}
