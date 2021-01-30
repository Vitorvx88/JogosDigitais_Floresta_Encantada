using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
         
           ControladorDoGame.istancia.AtivarGameOver();
            
           Temporizador.Stop();
          //  Player.istancia.Destruir();
        }
    }
}
