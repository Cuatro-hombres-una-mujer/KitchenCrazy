using System.Collections.Generic;
using Food;
using Food.Order;

namespace Entities
{
    public class Client
    {
        private List<Order> _orders;
        private bool _isWalking;
        private string _name;

        public Client(bool isWalking, string name)
        {
            _isWalking = isWalking;
            _name = name;
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