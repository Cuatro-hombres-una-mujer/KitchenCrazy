using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class ClientPool
    {
        private readonly IMovementStrategy _movementStrategy;
        private readonly Vector2 _vectorInitialPosition;
        private readonly GameObject _clientPrefab;

        private readonly List<GameObject> _entities;
        private IDictionary<string, Client> _clients;

        private readonly int _quantity;

        public ClientPool(int quantity, GameObject clientPrefab,
            Vector2 vectorInitialPosition, IMovementStrategy movementStrategy)
        {
            _quantity = quantity;
            _clientPrefab = clientPrefab;
            _vectorInitialPosition = vectorInitialPosition;

            _entities = new List<GameObject>();
            _clients = new Dictionary<string, Client>();

            _movementStrategy = movementStrategy;

            GenerateEntities();
        }

        private void GenerateEntities()
        {
            for (int i = 0; i < _quantity; i++)
            {
                var gameObject = GameObject.Instantiate(_clientPrefab,
                    _vectorInitialPosition, Quaternion.identity);

                gameObject.SetActive(false);
                _entities.Add(gameObject);

                var client = new Client(false,
                    gameObject.name);

                _clients[gameObject.name] = client;
            }
        }

        public void Spawn()
        {
            var clientGameObject = GetFreeClient();

            if (clientGameObject == null)
            {
                return;
            }

            clientGameObject.SetActive(true);

            var client = GetClient(clientGameObject.name);
            client.StartWalk();
        }

        public Client GetClient(string name)
        {
            return _clients[name];
        }

        public GameObject GetFreeClient()
        {
            foreach (var entity in _entities)
            {
                if (!entity.activeSelf)
                {
                    return entity;
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