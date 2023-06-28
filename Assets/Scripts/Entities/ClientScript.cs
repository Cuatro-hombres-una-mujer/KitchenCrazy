using System;
using System.Collections.Generic;
using DefaultNamespace.Text;
using Entities;
using UnityEngine;

public class ClientScript : MonoBehaviour
{
    
    private ClientInventoryText _clientInventoryText;
    private const string ClientNameInventory = "client_inventory";

    private Client _client;
    private ClientPool _clientPool;
    private Rigidbody2D _rigidbody;
    
    [SerializeField] private float speed = 0.15f;
    [SerializeField] private GameObject clientInventoryGameObject;

    void Update()
    {

        if (_clientPool == null)
        {
            _clientPool = ClientHandlerScript.GetMainClientPool();
            _client = _clientPool.GetClient(name);

            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        /*if (!_client.IsWalking())
        {
            Debug.Log("Pruebarrrr");
            return;
        }
        
        IMovementStrategy movementStrategy = _clientPool.GetMovementStrategy();
        //Vector2 vectorMovement = movementStrategy.Move();
        
        Vector2 position = _rigidbody.position;

        Vector2 newVector = new Vector2(-1, 0);

        _rigidbody.MovePosition(position + newVector * speed * Time.deltaTime);
        */
        
        
    }

    private void OnMouseDown()
    {

        if (_clientPool == null)
        {
            _clientPool = ClientHandlerScript.GetMainClientPool();
            _client = _clientPool.GetClient(name);

            _rigidbody = GetComponent<Rigidbody2D>();
        }

        var clientInventoryText = ClientInventoryScript.GetClientInventoryText();
        var player = PlayerMovement.GetPlayer();
        
        clientInventoryText.SetTitle(_client.Name);

        for (var i = 0; i < _client.GetOrders().Count; i++)
        {
            var order = _client.GetOrders()[i];
            var item = order.ItemOrdered;
            
            var orderFormat = item.Name + " - " + item.Quantity;

            var part = clientInventoryText.GetPart(i);
            part.UpdateText(orderFormat);
            part.Made(order.IsReady);
            
        }

        player.OpenInventory(ClientNameInventory);
        clientInventoryGameObject.SetActive(true);
        
    }

    private void OnCollisionEnter(Collision other)
    {
        _client.StopWalk();
    }
    
}