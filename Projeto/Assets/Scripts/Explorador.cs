using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Explorador : MonoBehaviour
{
    private float tempo;
    public GameObject joia;
    public GameObject explorador;
    public GameObject portaExplorador;
    public GameObject texto;
    public GameObject texto1;
    public GameObject texto2;
    public GameObject texto3;
    private bool verdadeiro;


    void Start()
    {
        verdadeiro = false;
        tempo = 0;
    }
     void Update()
    {

        if (verdadeiro)
        {
           
            tempo += Time.deltaTime;
            if (tempo >= 1)
            {
                texto.SetActive(true);

            }
            if (tempo >= 18)
            {
                texto1.SetActive(false);
                joia.SetActive(true);
                texto2.SetActive(true);
            }
            if (tempo >= 26)
            {
                texto.SetActive(false);
                texto2.SetActive(false);
                joia.SetActive(false);
                explorador.SetActive(false);
                texto3.SetActive(true);


            }
            if (tempo >= 34) {
                texto3.SetActive(false);
            }
            if (tempo >= 35)
            {
                SceneManager.LoadScene("Final");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("opa!");
            Temporizador.PararTempo();
            verdadeiro = true;
            portaExplorador.SetActive(false);
        }
    }
}
