using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterKIll : MonoBehaviour
{
    private Rigidbody2D rig;
    // Start is called before the first frame update


    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Sap")
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 7, ForceMode2D.Impulse);
                ControladorDoGame.istancia.pontuacaoTotal = ControladorDoGame.istancia.pontuacaoTotal + 20;
                ControladorDoGame.istancia.att(ControladorDoGame.istancia.pontuacaoTotal);
            }
            if (collision.gameObject.tag == "Pass")
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 7, ForceMode2D.Impulse);
                ControladorDoGame.istancia.pontuacaoTotal = ControladorDoGame.istancia.pontuacaoTotal + 40;
                ControladorDoGame.istancia.att(ControladorDoGame.istancia.pontuacaoTotal);
            }
        }
    }

}
