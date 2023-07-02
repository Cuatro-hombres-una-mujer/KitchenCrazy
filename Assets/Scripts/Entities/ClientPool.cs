using System;
using System.Collections.Generic;
using Food;
using Food.Order;
using Helper;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Entities
{
    public class ClientPool
    {

        private readonly List<string> _randomNames;
        private readonly IMovementStrategy _movementStrategy;
        private readonly Vector2 _vectorInitialPosition;
        private readonly GameObject _clientPrefab;
        
        private readonly IDictionary<string, Client> _clients;

        private readonly int _quantity;

        public ClientPool(int quantity, GameObject clientPrefab,
            Vector2 vectorInitialPosition, IMovementStrategy movementStrategy,
            List<string> randomNames)
        {
            _quantity = quantity;
            _clientPrefab = clientPrefab;
            _vectorInitialPosition = vectorInitialPosition;

            _clients = new Dictionary<string, Client>();

            _movementStrategy = movementStrategy;
            _randomNames = randomNames;
            
            GenerateEntities();
        }

        private void GenerateEntities()
        {
            for (var i = 0; i < _quantity; i++)
            {
                var gameObject = GameObject.Instantiate(_clientPrefab,
                    _vectorInitialPosition, Quaternion.identity);

                gameObject.SetActive(false);
          

                var realName = ListHelper.RandomValueList(_randomNames);
                
                var client = new Client(false,
                    gameObject.name, realName, gameObject);

                var orderGenerator = ItemFoodStorageScript.GetOrderGenerator();
                
                Debug.Log(">> GENERATING NEW ORDER FOR CLIENT");
                client.SetOrders(orderGenerator.Generate());
                
                _clients[gameObject.name] = client;
            }
        }

        public void Spawn(LocationClient location)
        {
            var clientGameObject = GetFreeClient();

            if (clientGameObject == null)
            {
                return;
            }

            clientGameObject.SetActive(true);
            var transform = clientGameObject.transform;

            var newPosition = new Vector3(location.x, location.y, transform.position.z);
            transform.position = newPosition;
            
            var client = GetClient(clientGameObject.name);
            client.StartWalk();
        }

        public void UnSpawn(Client client)
        {
            var gameObjectClient = client.ClientObject;
            gameObjectClient.SetActive(false);
        }

        public Client GetClient(string name)
        {
            return _clients[name];
        }

        public GameObject GetFreeClient()
        {
            foreach (var client in _clients.Values)
            {
                var clientGameObject = client.ClientObject;
                
                if (!clientGameObject.activeSelf)
                {
                    return clientGameObject;
                }
            }

            return null;
        }

        public IMovementStrategy GetMovementStrategy()
        {
            return _movementStrategy;
        }

    }
}