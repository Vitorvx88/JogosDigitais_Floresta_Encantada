using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rato : MonoBehaviour
{
    public float VelPass;
    public float moverPass;
    public static Passaro istancia;
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
    private AudioSource SoundJ;



    private void Start()
    {
        SoundJ = GetComponent<AudioSource>();
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
        colisao = Physics2D.Linecast(DireitaMonster.position, EsquerdaMonster.position, layer);
        if (colisao)
        {
            aux = true;
           

            TEst.GetComponent<Player>().TomarDano();
            Player.GetComponent<Player>().TomarDano();
            //Debug.Log("dano");
            // ControladorDoGame.istancia.TEst(10);

        }
        else
            aux = false;


    }
    public void Dead()
    {
        SoundJ.Play();
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
        }
        if (col.gameObject.tag == "Player" && aux == false)
        {
            float height = col.contacts[0].point.y - KIll.position.y;

            if (height < 0)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
                Dead();
            }
        }
        else
        {
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 12f, ForceMode2D.Impulse);
        }

    }
}