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

                var idObject = IdentifierUtility.GenerateRandoId();
                gameObject.name = idObject;
                
                var client = new Client(false,
                    gameObject.name, null, gameObject);

                Debug.Log(">> GENERATING NEW ORDER FOR CLIENT");

                _clients[gameObject.name] = client;
            }
        }

        public void Spawn(LocationClient location)
        {

            var clientFree = GetFreeClient();
            var clientGameObject = clientFree.ClientObject;

            if (clientGameObject == null)
            {
                return;
            }

            clientGameObject.SetActive(true);
            var transform = clientGameObject.transform;

            Debug.Log("----------------------");
            Debug.Log("x: " + location.x);
            Debug.Log("y: " + location.y);
            Debug.Log("----------------------");

            var newPosition = new Vector3(location.x, location.y, transform.position.z);
            transform.position = newPosition;

            var realName = ListHelper.RandomValueList(_randomNames);

            var client = GetClient(clientGameObject.name);
            client.Name = realName;

            var orderGenerator = ItemFoodStorageScript.GetOrderGenerator();
            

            client.SetOrders(orderGenerator.Generate());


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

        public Client GetFreeClient()
        {
            foreach (var client in _clients.Values)
            {
                var clientGameObject = client.ClientObject;
                
                if (!clientGameObject.activeSelf)
                {
                    return client;
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