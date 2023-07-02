using System;
using UnityEngine;

namespace DefaultNamespace.Time
{
    public class TimeHandlerScript : MonoBehaviour
    {
        
        private int _nextUpdate = 1;
        [SerializeField] private int seconds;
        private static TimeHandler _timeHandler;

        private void Awake()
        {
            _timeHandler = new TimeHandler(seconds);
        }

        public void Update()
        {
            
            if(UnityEngine.Time.time >= _nextUpdate){
                _nextUpdate= Mathf.FloorToInt(UnityEngine.Time.time) + 1;
                _timeHandler.DiscountSecond();
            }
            
            
        }

        public static TimeHandler GetTimeHandler()
        {
            return _timeHandler;
        }
        
    }
}