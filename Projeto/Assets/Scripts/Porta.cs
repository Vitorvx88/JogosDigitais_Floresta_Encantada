using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public GameObject portaFechada;
    public GameObject portaAberta;
    public GameObject jogador;
    private bool IsAberta;

    // Start is called before the first frame update
    void Start()
    {
        IsAberta = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsAberta)
            {
                portaFechada.SetActive(false);
                portaAberta.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            jogador.GetComponent<Player>().ReceberKey();
            Debug.Log("Recebeu a chave!");
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
