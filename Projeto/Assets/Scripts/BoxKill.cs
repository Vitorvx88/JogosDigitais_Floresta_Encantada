using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxKill : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Monstro;
    public BoxCollider2D BoxCollider2D;
    private Animator anim;
    public int pass;
    public int sap;
    public int rato;

    void Start()
    {
        anim = GetComponent<Animator>();

    }
    private void Update()
    {
       
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
            ControladorDoGame.istancia.pontuacaoTotal = ControladorDoGame.istancia.pontuacaoTotal + pass + sap + rato;
            ControladorDoGame.istancia.att(ControladorDoGame.istancia.pontuacaoTotal);

            if (sap == 20)
            {
                Monstro.GetComponent<Sapo>().Dead();
                Destroy(gameObject);
            }
            if (pass == 30)
            {
                Monstro.GetComponent<Passaro>().Dead();
                Destroy(gameObject);
            }
            if (rato == 10)
            {
                Monstro.GetComponent<Rato>().Dead();
                Destroy(gameObject);
            }
        }
    }
}
