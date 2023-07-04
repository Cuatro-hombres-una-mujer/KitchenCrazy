using System.Collections.Generic;
using DefaultNamespace.Text;
using Helper;
using UnityEngine;

namespace Entities
{
    public class ClientHandler
    {

        private const int QuantityMaxClients = 4;
        private readonly ClientPool _clientPool;
        private readonly List<LocationClient> _locations;
        private readonly ClientInventoryText _clientInventoryText;
        private readonly GameObject _clientHandlerInventory;

        public ClientHandler(ClientPool clientPool, GameObject clientHandlerInventory,
            List<LocationClient> locations, ClientInventoryText clientInventoryText)
        {
            _clientPool = clientPool;
            _clientHandlerInventory = clientHandlerInventory;
            _locations = locations;
            _clientInventoryText = clientInventoryText;
        }

        public void FinishOrder(Player.Player player, string clientName)
        {
            var client = _clientPool.GetClient(clientName);

            if (!client.AllOrdersAreReady())
            {
                //Warn it all orders are not ready!
                return;
            }
            
            //Give money
            
            _clientHandlerInventory.SetActive(false);
            player.CloseInventory();
            _clientPool.UnSpawn(client);
            GenerateClients();
        }

        public void FinishPartOrder(Player.Player player, int position, string clientName)
        {
            var client = _clientPool.GetClient(clientName);
            var order = client.GetOrders()[position];
            var itemOrdered = order.ItemOrdered;
            
            var inventory = player.Inventory;

            if (!inventory.HasItem(itemOrdered))
            {
                Debug.Log("Has no items");
                //Warn it, no has items
                return;
            }

            Debug.Log("Yes it contains the items");
            order.Ready();
            
            Debug.Log("Deleting items");
            inventory.DeleteItem(itemOrdered);
            var part = _clientInventoryText.GetPart(position);
            
            Debug.Log("Maded!");
            part.Made();

            FinishOrder(player, clientName);
            
            
        }

        public void GenerateClients()
        {
            var quantityClient = Random.Range(1, QuantityMaxClients);
            for (var i = 0; i < quantityClient; i++)
            {
                _clientPool.Spawn(GetFreeAndRandomLocation());
            }
            
        }

        public string GetViewingClientId()
        {
            return _clientInventoryText.GetClientId();
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