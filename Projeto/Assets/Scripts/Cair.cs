using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cair : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Plataforma;
    private float tempo;
    private bool Ativar;


    private void Start()
    {
        tempo = 0;
    }
    private void Update()
    {
        //Debug.Log(tempo);
        if (Ativar)
        {
            tempo += Time.deltaTime;
            if (tempo >= 1)
            {
                Plataforma.SetActive(false);
               
                if (tempo >= 2.5f)
                {

                    Plataforma.SetActive(true);
                    Ativar = false;
                    tempo = 0;
                }

            }
            

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Bom dia");
            //Plataforma.SetActive(true);
            Ativar = true;
        }
    }

}
