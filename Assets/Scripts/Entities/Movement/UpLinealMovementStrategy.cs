using UnityEngine;

namespace Entities
{
    public class UpLinealMovementStrategy : IMovementStrategy
    {

        private readonly Vector2 _vectorMovement = 
            new (0, -1);
        
        public Vector2 Move()
        {
            return _vectorMovement;
        }
        
    }
}