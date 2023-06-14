using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class ClientPool
    {
        private readonly Vector2 _vectorInitialPosition;
        private readonly GameObject _clientPrefab;

        private readonly List<GameObject> _entities;
        private IDictionary<string, Client> _clients;

        private readonly int _quantity;

        public ClientPool(int quantity, GameObject clientPrefab,
            Vector2 vectorInitialPosition)
        {
            _quantity = quantity;
            _clientPrefab = clientPrefab;
            _vectorInitialPosition = vectorInitialPosition;

            _entities = new List<GameObject>();
            _clients = new Dictionary<string, Client>();
        }

        private void GenerateEntities()
        {
            for (int i = 0; i < _quantity; i++)
            {
                var gameObject = GameObject.Instantiate(_clientPrefab,
                    _vectorInitialPosition, Quaternion.identity);

                _entities.Add(gameObject);

                //CREATE THE CLIENT

                //ADDED
            }
        }

        public void Spawn()
        {

            var client = GetFreeClient();
            client.SetActive(true);
            
            
            
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
    }
}