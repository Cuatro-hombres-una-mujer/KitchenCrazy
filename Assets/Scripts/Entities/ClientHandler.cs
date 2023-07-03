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
        private List<LocationClient> _locations;
        private ClientInventoryText _clientInventoryText;
        private readonly GameObject _clientHandlerInventory;

        public ClientHandler(ClientPool clientPool, GameObject clientHandlerInventory,
            List<LocationClient> locations)
        {
            _clientPool = clientPool;
            _clientHandlerInventory = clientHandlerInventory;
            _locations = locations;
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

            order.Ready();
            inventory.DeleteItem(itemOrdered);
            var part = _clientInventoryText.GetPart(position);
            part.Made();
            
        }

        public void GenerateClients()
        {
            var quantityClient = Random.Range(1, QuantityMaxClients);
            for (var i = 0; i < quantityClient; i++)
            {
                _clientPool.Spawn(GetFreeAndRandomLocation());
            }
            
        }

        public string GetViewingClient()
        {
            return _clientInventoryText.GetClientName();
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