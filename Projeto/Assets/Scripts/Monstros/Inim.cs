using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inim : MonoBehaviour
{
    public float VelPass;
    public float moverPass;
    public bool Direita;
    private float tempo;
    public bool TrocarRotation;
    private bool istroca;
    public bool inicial;
    private Animator anim;
    public GameObject Player;
    public int Pontos;
    public GameObject TEst;

    public Transform DireitaMonster;
    public Transform EsquerdaMonster;
    public Transform KIll;
    public LayerMask layer;
    private bool aux;
    private bool colisao;
    public GameObject Hit;



    private void Start()
    {
        aux = false;
        if (inicial)
        {
            transform.localScale = new Vector2(4.4f, transform.localScale.y);
        }
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Direita)
        {
            transform.Translate(Vector2.left * VelPass * Time.deltaTime);

        }
        else
        {
            transform.Translate(Vector2.right * VelPass * Time.deltaTime);

        }
        tempo += Time.deltaTime;
        if (tempo >= moverPass)
        {
            Direita = !Direita;
            tempo = 0f;
            if (TrocarRotation)
            {
                istroca = !istroca;
                if (istroca)
                {
                    transform.localScale = new Vector2(-4.4f, transform.localScale.y);
                }
                else
                    transform.localScale = new Vector2(4.4f, transform.localScale.y);


            }
            else
                transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
        }
     


    }
    public void Dead()
    {
        VelPass = 0;
        ControladorDoGame.istancia.ReceberPontos(Pontos);
        anim.SetTrigger("RatoKill");
        Destroy(gameObject, 0.34f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Dead")
        {
            Dead();
            Destroy(Hit);
        }

        if (col.gameObject.tag == "Player")
        {
            Player.GetComponent<Player>().TomarDano();
        }
      

    }
}
