using System;
using System.Collections;
using System.Collections.Generic;
using Entities.Player;
using UnityEngine;

public class OvenCollision : MonoBehaviour
{

    [SerializeField] private  GameObject ovenInventoryGuiGameObject;

    private const string InventoryName = "Oven_Inventory";
    private const string Oven = "Oven";
    private Player _player;

    private void Start()
    {
        StartCoroutine(StartWithDelay());
    }

    private IEnumerator StartWithDelay()
    {
        yield return new WaitForSeconds(1F);
        _player = PlayerMovement.GetPlayer();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Oven) && Input.GetKey(KeyCode.Space))
        {
            _player.OpenInventory(InventoryName);
            ovenInventoryGuiGameObject.SetActive(true);
        }
        
    }
}