using System.Collections.Generic;
using Food;
using Food.Order;

namespace Entities
{
    public class Client
    {
        private List<Order> _orders;
        private bool _isWalking;
        public string NameGameObject { get; }
        public string Name { get; }

        public Client(bool isWalking, string name, string realName)
        {
            _isWalking = isWalking;
            NameGameObject = name;
            Name = realName;
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
    }
}