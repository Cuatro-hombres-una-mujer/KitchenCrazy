using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadSystemData1 : MonoBehaviour
{
    public GameObject jugador;
    public string archivoDeGuardado;
    public ExampleData datosJuego = new ExampleData();

    private void Awake()
    {
        archivoDeGuardado = Application.dataPath + "/datosJuego.json";   //Ubicacion de la carpeta de guardado
        jugador = GameObject.FindGameObjectWithTag("Player");   //Buscar Jugador
    }

    
    private void SaveData()
    {
        ExampleData nuevosDatos = new ExampleData()
        {
            posicion = jugador.transform.position
        };
        

        string cadenaJson = JsonUtility.ToJson(nuevosDatos);
        File.WriteAllText(archivoDeGuardado, cadenaJson);
        Debug.Log("Archivo Guardado");

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            SaveData();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        if (File.Exists(archivoDeGuardado))
        {
            string textoJson = File.ReadAllText(archivoDeGuardado);
            datosJuego = JsonUtility.FromJson<ExampleData>(textoJson);
            
            Debug.Log("Posicion Jugador: " + datosJuego.posicion);
            jugador.transform.position = datosJuego.posicion;
        }
        else
        {
            Debug.Log("NO se encontro el archivo");
        }
    }
}