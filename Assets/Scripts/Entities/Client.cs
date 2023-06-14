using System.Collections.Generic;
using Food;

namespace Entities
{
    public class Client
    {
        private List<ItemFood> _requested;
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
    }
}