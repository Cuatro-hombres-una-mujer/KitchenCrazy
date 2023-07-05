using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Cronometro : MonoBehaviour
{

    private int _nextUpdate = 1;
    
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] private float timeInSeconds;
    
   public void UpdateTimeText()
   {

       var minutes = timeInSeconds / 60;
       var secondsRest = timeInSeconds % 60;
       
       // text.text = string.Format("{0:00}:{1:00}:{2:00}", tiempoMinutos, tiempoSegundos, tiempoDecimasSegundo);

       text.text = string.Format("{0:00}:{1:00}", minutes, secondsRest);
   }
   
   void Update()
    {
        if(Time.time >= _nextUpdate)
        {
            _nextUpdate= Mathf.FloorToInt(Time.time) + 1;
            timeInSeconds--;
            UpdateTimeText();
        }

        if (timeInSeconds == 0)
        {
            //Finished game
            SceneManager.LoadScene(5);
        }
        
    }
}
