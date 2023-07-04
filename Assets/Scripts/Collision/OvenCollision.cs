using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Gui;
using Entities.Player;
using Gui.Script;
using UnityEngine;

public class OvenCollision : MonoBehaviour
{

    [SerializeField] private  GameObject ovenInventoryGuiGameObject;

    private OvenGuiHandler _ovenGuiHandler;
    
    private const string InventoryName = "Oven_Inventory";
    private const string Oven = "Oven";
    private Player _player;

    private void Start()
    {
        StartCoroutine(StartWithDelay());
    }

    private IEnumerator StartWithDelay()
    {
        yield return new WaitForSeconds(2F);
        _player = PlayerMovement.GetPlayer();
        _ovenGuiHandler = OvenGuiHandlerScript.GetOvenGuiHandler();

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Oven) && Input.GetKey(KeyCode.Space))
        {
            _player.OpenInventory(InventoryName);
            ovenInventoryGuiGameObject.SetActive(true);

            if (_ovenGuiHandler == null)
            {
                return;
            }

            _ovenGuiHandler.GetInventoryGuiHandler().Refresh();
        }
        
    }
}