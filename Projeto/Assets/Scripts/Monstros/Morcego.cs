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
        Pontos = 0;
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

    public void Dead()
    {
        ControladorDoGame.istancia.ReceberPontos(Pontos);
        anim.SetTrigger("kill");
        Destroy(gameObject, 0.5f);
    }
}
