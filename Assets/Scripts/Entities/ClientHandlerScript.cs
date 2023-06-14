using System.Collections;
using System.Collections.Generic;
using Entities;
using UnityEngine;

public class ClientHandlerScript : MonoBehaviour
{
    private static ClientPool _clientPool;
    [SerializeField] private int quantity;
    [SerializeField] private GameObject clientPrefab;
    [SerializeField] private int x;
    [SerializeField] private int y;

    void Start()
    {
        Vector2 initialPositionVector = new Vector2(x, y);
        _clientPool = new ClientPool(quantity, clientPrefab, initialPositionVector);
    }

    public static ClientPool GetMainClientPool()
    {
        return _clientPool;
    }
    
}