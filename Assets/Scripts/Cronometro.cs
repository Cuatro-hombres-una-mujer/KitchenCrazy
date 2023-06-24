using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textoCrono;
    [SerializeField] private float tiempo;

    private int tiempoMinutos, tiempoSegundos, tiempoDecimasSegundo;


   public void CronometroGame()
   {
        tiempo -= Time.deltaTime;
        tiempoMinutos = Mathf.FloorToInt(tiempo / 60);
        tiempoSegundos = Mathf.FloorToInt(tiempo % 60);
        tiempoDecimasSegundo = Mathf.FloorToInt((tiempo % 1) * 100);


        textoCrono.text = string.Format("{0:00}:{1:00}:{2:00}", tiempoMinutos, tiempoSegundos, tiempoDecimasSegundo);
   }
    void Update()
    {
        CronometroGame();
    }
}
