using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDamageBos : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bosDAmage;
    private float vida;
    private void Start()
    {
        vida = 10;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Algo");
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
            bosDAmage.GetComponent<Bos_1>().PerderVida(4f);

            PerderVida(4);
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
