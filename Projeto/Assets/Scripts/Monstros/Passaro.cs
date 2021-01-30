using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passaro : MonoBehaviour
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

    private void Start()
    {
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
        anim.SetTrigger("Pass");
        Destroy(gameObject, 0.40f);
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dead")
        {
            anim.SetTrigger("Pass");

            Destroy(gameObject, 0.25f);
        }
    }

}
