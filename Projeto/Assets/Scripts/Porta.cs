using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public GameObject Bloco1;
    public GameObject Bloco2;
    public GameObject Bloco3;
    public GameObject Box;
    public GameObject jogador;
    private bool IsAberta;
    private float tempo;

    //Start is called before the first frame update
    void Start()
    {
        IsAberta = false;
        tempo = 0f;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAberta)
        {
            Bloco1.SetActive(false);
            tempo += Time.deltaTime;
            if (tempo >= 1)
            {
                Bloco2.SetActive(false);
                if (tempo >= 2)
                {
                    Bloco3.SetActive(false);
                    Box.SetActive(false);
                }
            }
        }

       
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            if (jogador.GetComponent<Player>().checarKey())
            {      
                IsAberta = true;
            }
        }
    }
}
