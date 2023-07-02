using System.Collections.Generic;
using DefaultNamespace.Text;
using Helper;
using UnityEngine;

namespace Entities
{
    public class ClientHandler
    {

        private const int QuantityMaxClients = 2;
        private readonly ClientPool _clientPool;
        private List<LocationClient> _locations;
        private ClientInventoryText _clientInventoryText;
        private readonly GameObject _clientHandlerInventory;

        public ClientHandler(ClientPool clientPool, GameObject clientHandlerInventory)
        {
            _clientPool = clientPool;
            _clientHandlerInventory = clientHandlerInventory;
        }

        public void FinishOrder(Player.Player player, string clientName)
        {
            var client = _clientPool.GetClient(clientName);
            var gameObjectClient = client.ClientObject;

            if (!client.AllOrdersAreReady())
            {
                //Warn it all orders are not ready!
                return;
            }
            
            //Give money
            
            _clientHandlerInventory.SetActive(false);
            player.CloseInventory();
            _clientPool.UnSpawn(client);
        }

        public void FinishPartOrder(Player.Player player, int position, string clientName)
        {
            var client = _clientPool.GetClient(clientName);
            var order = client.GetOrders()[position];
            var itemOrdered = order.ItemOrdered;
            
            var inventory = player.Inventory;

            if (!inventory.HasItem(itemOrdered))
            {
                //Warn it, no has items
                return;
            }

            order.Ready();
            inventory.DeleteItem(itemOrdered);
            var part = _clientInventoryText.GetPart(position);
            part.Made();
            
        }

        public void GenerateClients()
        {
            var quantityClient = Random.Range(0, QuantityMaxClients);
            for (var i = 0; i < quantityClient; i++)
            {
                _clientPool.Spawn(GetFreeAndRandomLocation());
            }
            
        }

        public LocationClient GetFreeAndRandomLocation()
        {
           var locationClient = ListHelper.RandomValueList(_locations);

           if (locationClient.InUse)
           {
               return GetFreeAndRandomLocation();
           }

           return locationClient;
        }
        
    }
}