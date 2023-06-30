using System;
using System.Collections;
using System.Collections.Generic;
using Entities;
using Entities.Player;
using UnityEngine;

public class ClientHandlerScript : MonoBehaviour
{
    private static ClientPool _clientPool;
    private Player _player;
    private const string ClientNameInventory = "client_inventory";
    
    [SerializeField] private List<string> randomNames;
    [SerializeField] private int quantity;
    [SerializeField] private GameObject clientPrefab;
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private GameObject clientInventoryGameObject;
    
    void Start()
    {

        var initialPositionVector = new Vector2(x, y);
        IMovementStrategy movementStrategy = new UpLinealMovementStrategy();
        
        _clientPool = new ClientPool(quantity, clientPrefab, initialPositionVector, 
            movementStrategy, randomNames);
        Debug.Log("Creating Client Pool");
        
    }

    private void Update()
    {
        if (_player == null)
        {
            _player = PlayerMovement.GetPlayer();
        }
        
        if (Input.GetKey(KeyCode.Escape) && _player.GetOpenedInventory() == ClientNameInventory)
        {
            clientInventoryGameObject.SetActive(false);
            _player.CloseInventory();
        }
    }

    public static ClientPool GetMainClientPool()
    {
        return _clientPool;
    }
    
}