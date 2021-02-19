using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morcego : MonoBehaviour
{
    public int Pontos;
    private Animator anim;
    public GameObject controlador;
    public float VelPass, tempo;
    public bool Direita;
    public float moverPass;
    public bool TrocarRotation;
    private bool istroca;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Direita)
        {
            transform.Translate(Vector2.up * VelPass * Time.deltaTime);

        }
        else
        {
            transform.Translate(Vector2.down * VelPass * Time.deltaTime);

        }
        tempo += Time.deltaTime;
        if (tempo >= moverPass)
        {
            Direita = !Direita;
            tempo = 0;
        }

    }
    public void Parar()
    {
        VelPass = 0;
    }

    public void Dead()
    {
        Parar();
        ControladorDoGame.istancia.ReceberPontos(Pontos);
        anim.SetTrigger("Kill");
        Destroy(gameObject, 0.30f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dead")
        {
            Dead();
        }
      
    }
}
