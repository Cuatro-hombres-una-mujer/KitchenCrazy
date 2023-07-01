using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Gui;
using Entities.Player;
using UnityEngine;

namespace Gui.Script
{
    public class OvenGuiHandlerScript : MonoBehaviour
    {
        private static OvenGuiHandler _ovenGuiHandler;
        private Player _player;

        [SerializeField] private GameObject firstButtonOven;
        [SerializeField] private GameObject secondButtonOven;
        [SerializeField] private GameObject thirdButtonOven;

        private void Start()
        {
            StartCoroutine(StartWithDelay());
        }

        private IEnumerator StartWithDelay()
        {

            yield return new WaitForSeconds(1F);
            
            _ovenGuiHandler = new OvenGuiHandler();
            _player = PlayerMovement.GetPlayer();
        }

        public static OvenGuiHandler GetOvenGuiHandler()
        {
            return _ovenGuiHandler;
        }

        public void GetFoodCookedOnClickButton(int position)
        {
            var slotOven = _ovenGuiHandler.GetSlot(position);
            slotOven.GetFoodPrepared(_player);
        }
        
        
        
    }
}