using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    public Text cronometro_txt;
    private float cronometro=0f; // tempo 
    public static bool stopTime;
    private int tempoMaximo=500;

    void Start()
    {
        stopTime = false;
    }
    void Update()
    {
        if(cronometro>=tempoMaximo)
        {
            stopTime = true;
        }   
        if (stopTime==false)
        {
            cronometro += Time.deltaTime;
            cronometro_txt.text = cronometro.ToString("F0");

        }
        else
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
