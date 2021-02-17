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
    private int tempoMaximo=10000000;
    private string aux1;

    public GameObject pausePainel;

    void Start()
    {
        stopTime = false;
        this.segundos=ControladorDoGame.istancia.enviarTempoS();
        this.minutos=ControladorDoGame.istancia.enviarTempoM();
        minutos_txt.text = minutos.ToString("F0");
    }
    void Update()
    {
        if(minutos>=tempoMaximo)
        {
            Debug.Log(minutos);
            Debug.Log(tempoMaximo);
            stopTime = true;
            //ControladorDoGame.istancia.resetarPontos();
        }   
        if (stopTime==false)
        {
            segundos += Time.deltaTime;
            if (segundos < 9.5)
            {
                aux1 = "0";
                segundos_txt.text = aux1 +segundos.ToString("F0");
            }
            else
            {
                segundos_txt.text = segundos.ToString("F0");
            }
            
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
            ControladorDoGame.istancia.AtivarGameOverBos();
            pausePainel.SetActive(true);
            Time.timeScale = 0f;
            Destroy(gameObject);
         
        }
        ControladorDoGame.istancia.receberTempo(segundos, minutos);
        
    }
    public static void Stop()
    {
        stopTime = true;
    }
}
