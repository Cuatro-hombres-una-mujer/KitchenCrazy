using System;
using UnityEngine;

namespace DefaultNamespace.Time
{
    public class TimeHandlerScript : MonoBehaviour
    {
        [SerializeField] private int seconds;
        private static TimeHandler _timeHandler;

        private void Awake()
        {
            _timeHandler = new TimeHandler(seconds);
        }

        public void Update()
        {
            _timeHandler.DiscountSecond();
        }

        public static TimeHandler GetTimeHandler()
        {
            return _timeHandler;
        }
        
    }
}