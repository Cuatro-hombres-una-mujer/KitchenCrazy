using System.Collections;
using System.Collections.Generic;
using Entities;
using UnityEngine;

public class ClientHandlerScript : MonoBehaviour
{
    private static ClientPool _clientPool;

    [SerializeField] private List<string> randomNames;
    [SerializeField] private int quantity;
    [SerializeField] private GameObject clientPrefab;
    [SerializeField] private float x;
    [SerializeField] private float y;

    void Start()
    {
        Vector2 initialPositionVector = new Vector2(x, y);
        IMovementStrategy movementStrategy = new UpLinealMovementStrategy();
        
        _clientPool = new ClientPool(quantity, clientPrefab, initialPositionVector, 
            movementStrategy, randomNames);
        
    }
    
    public static ClientPool GetMainClientPool()
    {
        return _clientPool;
    }
    
}