using System;
using System.Collections;
using System.Collections.Generic;
using Entities;
using Entities.Player;
using Helper;
using UnityEngine;

public class ClientHandlerScript : MonoBehaviour
{
    
    private const string Root = "Assets/Json/";
    private const string FileName = "client_location.json";
    
    private static ClientPool _clientPool;
    private static ClientHandler _clientHandler;

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

        var locations = JsonHelper.
            GetAsJson<LocationClient>(Root + FileName);

        _clientHandler = new ClientHandler(_clientPool, clientInventoryGameObject, locations);
        Debug.Log("Creating Client Pool");
        
        StartCoroutine(SpawnClientInStart());
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

    private IEnumerator SpawnClientInStart()
    {
        yield return new WaitForSeconds(2F);
        _clientHandler.GenerateClients();
    }

    public void OnClickOrder(int position)
    {
        var clientName = _clientHandler.GetViewingClient();
        _clientHandler.FinishPartOrder(_player, position, clientName);   
    }
    public static ClientPool GetMainClientPool()
    {
        return _clientPool;
    }
}