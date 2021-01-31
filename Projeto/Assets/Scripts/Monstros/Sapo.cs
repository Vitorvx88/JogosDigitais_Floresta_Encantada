using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapo : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;
    public static Sapo istancia;
    public Transform DireitaMonster;
    public Transform EsquerdaMonster;

    public Transform DireitaMonster2;
    public Transform EsquerdaMonster2;

    public Transform KIll;
    public LayerMask layer;
    //public GameObject Player;
    public GameObject TEst;
    private bool colisao;
    private bool colisao2;
    public int Pontos;
    private bool aux;
    // Start is called before the first frame update
    private void Start()
    {
        aux = false;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        colisao = Physics2D.Linecast(DireitaMonster.position, EsquerdaMonster.position, layer);
        colisao2 = Physics2D.Linecast(DireitaMonster2.position, EsquerdaMonster2.position, layer);
        if (colisao||colisao2)
        {
            //Player.GetComponent<Player>().TomarDano();
            //Debug.Log("DAno");
            TEst.GetComponent<Player>().TomarDano();
            aux = true;
        }
        else
            aux = false;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Dead")
        {
            Dead();
        }
        if (col.gameObject.tag == "Player" && aux == false)
        {
            float height = col.contacts[0].point.y - KIll.position.y;
            //Debug.Log(height);
            if (height !=0)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
                Dead();
            }

        }
        else
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 12f, ForceMode2D.Impulse);

    }
    public void Dead()
    {
        ControladorDoGame.istancia.ReceberPontos(Pontos);
        anim.SetTrigger("kill");
        Destroy(gameObject, 0.25f);
    }


}
