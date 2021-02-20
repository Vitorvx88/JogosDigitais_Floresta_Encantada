using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDamageBos : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bosDAmage;

    private float vida;
    private Rigidbody2D rig;
    private AudioSource SoundJ;
    private void Start()
    {
        SoundJ = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();
        vida = 50;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 12f, ForceMode2D.Impulse);

            bosDAmage.GetComponent<Bos_1>().PerderVida(6f);

            PerderVida(6);
            checarVida();
        }

    }
    void PerderVida(float vida)
    {
        SoundJ.Play();
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
