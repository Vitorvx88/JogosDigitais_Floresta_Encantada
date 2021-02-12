using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarDano : MonoBehaviour
{
    public GameObject Jogador;
    public GameObject Espinhos;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           
            Jogador.GetComponent<Player>().TomarDano();
           // Espinhos.GetComponent<Ativar>().Desativar();
        }
    }
}
