using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Audio;
using DefaultNamespace.Text;
using Helper;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Entities
{
    public class ClientHandler
    {

        private TextMeshProUGUI _ordersCompleted;
        private const int QuantityMaxClients = 4;
        private readonly ClientPool _clientPool;
        private readonly List<LocationClient> _locations;
        private readonly ClientInventoryText _clientInventoryText;
        private readonly GameObject _clientHandlerInventory;

        public ClientHandler(ClientPool clientPool, GameObject clientHandlerInventory,
            List<LocationClient> locations, ClientInventoryText clientInventoryText,
            TextMeshProUGUI ordersCompleted)
        {
            _clientPool = clientPool;
            _clientHandlerInventory = clientHandlerInventory;
            _locations = locations;
            _clientInventoryText = clientInventoryText;
            _ordersCompleted = ordersCompleted;
        }

        public void FinishOrder(Player.Player player, string clientName)
        {
            var client = _clientPool.GetClient(clientName);

            if (!client.AllOrdersAreReady())
            {
                return;
            }
            
            //Give money
            
            player.AddOrderComplete();
            _ordersCompleted.text = "Pedidos: " + player.GetOrderComplete() + "";
            

            Debug.Log("ALL ORDERS IS READY");
            _clientHandlerInventory.SetActive(false);
            player.CloseInventory();
            _clientPool.UnSpawn(client);
            GenerateClients();
            
            client.UnViewOrder();
            
            foreach (var orderPartInventoryText in _clientInventoryText.GetParts())
            {
                orderPartInventoryText.UnMade();
            }
            
        }

        public void FinishPartOrder(Player.Player player, int position, string clientName)
        {
            var client = _clientPool.GetClient(clientName);
            var order = client.GetOrders()[position];
            var itemOrdered = order.ItemOrdered;

            var audioHandler = AudioHandlerScript.GetAudioHandler();
            
            var inventory = player.Inventory;

            if (!inventory.HasItem(itemOrdered))
            {
                audioHandler.PlaySound(SoundType.Error);
                return;
            }

            if (order.IsReady)
            {
                audioHandler.PlaySound(SoundType.Error);
                return;
            }
            
            order.Ready();
            inventory.DeleteItem(itemOrdered);
            var part = _clientInventoryText.GetPart(position);
            
            audioHandler.PlaySound(SoundType.Correct);
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

        public IEnumerator GenerateClientsWithDelay(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            
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