using System.Collections.Generic;
using Food;
using Food.Order;
using UnityEngine;

namespace Entities
{
    public class Client
    {
        private List<Order> _orders;
        private bool _isWalking;
        public string NameGameObject { get; }
        public string Name { get; }

        public GameObject ClientObject { get; set; }

        public Client(bool isWalking, string name, string realName,
             GameObject clientObject)
        {
            _isWalking = isWalking;
            NameGameObject = name;
            Name = realName;
            ClientObject = clientObject;
        }

        public void SetOrders(List<Order> orders)
        {
            _orders = orders;
        }
        
        public void StartWalk()
        {
            _isWalking = true;
        }

        public void StopWalk()
        {
            _isWalking = false;
        }

        public bool IsWalking()
        {
            return _isWalking;
        }

        public List<Order> GetOrders()
        {
            return _orders;
        }

        public bool AllOrdersAreReady()
        {
            foreach (var order in _orders)
            {
                if (!order.IsReady)
                {
                    return false;
                }
            }

            return true;
        }
        
    }
}