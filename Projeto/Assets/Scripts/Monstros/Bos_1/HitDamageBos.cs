using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDamageBos : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bosDAmage;

    private float vida;
    private Rigidbody2D rig;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        vida = 50;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 12f, ForceMode2D.Impulse);

            bosDAmage.GetComponent<Bos_1>().PerderVida(40f);

            PerderVida(40);
            checarVida();
        }

    }
    void PerderVida(float vida)
    {
        this.vida += -vida;
    }
    void checarVida()
    {
        if(this.vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
