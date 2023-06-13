using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    int score;
    public static Score instance;
    public TextMeshProUGUI text;
    
    void Start()
    {

        if(instance == null)
        {
            instance = this;
        }
        
    }

 
}
