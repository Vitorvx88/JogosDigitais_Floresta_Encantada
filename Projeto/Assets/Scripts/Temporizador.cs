using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    public Text segundos_txt;
    public Text minutos_txt;
    private float segundos=0f;
    private float minutos = 0f;
    private float maximoSegundos = 60f;
    public static bool stopTime;
    private int tempoMaximo=10;
    public GameObject pausePainel;

    void Start()
    {
        stopTime = false;
    }
    void Update()
    {
        if(minutos>=tempoMaximo)
        {
            stopTime = true;
        }   
        if (stopTime==false)
        {
            segundos += Time.deltaTime;
            segundos_txt.text = segundos.ToString("F0");
            if (segundos>=maximoSegundos)
            {
                minutos++;
                segundos = 0 + 1;
                minutos_txt.text = minutos.ToString("F0");

            }


        }
        else
        {
            stopTime = true;
            ControladorDoGame.istancia.AtivarGameOver();
            pausePainel.SetActive(true);
            Time.timeScale = 0f;
         
        }
        
    }
    public static void Stop()
    {
        stopTime = true;
    }
}
