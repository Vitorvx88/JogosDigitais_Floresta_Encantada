using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDmg3 : MonoBehaviour
{
    public GameObject bosDAmage;

    private float vida;
    private Rigidbody2D rig;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        vida = 80;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 12f, ForceMode2D.Impulse);

            bosDAmage.GetComponent<Bos3>().PerderVida(/*13.6f*/80f);

            PerderVida(/*13.6f*/80f);
            checarVida();
        }

    }
    void PerderVida(float vida)
    {
        this.vida += -vida;
    }
    void checarVida()
    {
        if (this.vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
