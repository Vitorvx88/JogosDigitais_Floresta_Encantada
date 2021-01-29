using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public float TempoDeVida;
    public int pass;
    public int sap;
    // Start is called before the first frame update
    void Start()
    {
 
       TempoDeVida = 3f;
       Destroy(gameObject, TempoDeVida);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * 13 * Time.deltaTime*1);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pass")
        {
            ControladorDoGame.istancia.pontuacaoTotal = ControladorDoGame.istancia.pontuacaoTotal + pass;
            ControladorDoGame.istancia.att(ControladorDoGame.istancia.pontuacaoTotal);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Sap")
        {
            ControladorDoGame.istancia.pontuacaoTotal = ControladorDoGame.istancia.pontuacaoTotal + sap;
            ControladorDoGame.istancia.att(ControladorDoGame.istancia.pontuacaoTotal);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Player")
        {
            ControladorDoGame.istancia.pontuacaoEstrela += +1;
            ControladorDoGame.istancia.attEstrela(ControladorDoGame.istancia.pontuacaoEstrela);
            Destroy(gameObject);
        }

    }
}
