using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int strikes = 0;
    public HUD hud;
    public static GameManager Instance {get; private set;}
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null) {
            Instance = this;
            Debug.Log("Se crea gamemanager");
        }
        else {
            Debug.Log("Se detectan 2 GameManagers en escena");
        }
    }

    public void GainStrike() {
        hud.StrikeActive(strikes);
        strikes += 1;
         if (strikes == 3) {
            SceneManager.LoadScene(5);
        }
    }
    
}
