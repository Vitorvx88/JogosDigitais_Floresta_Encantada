using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimKill : MonoBehaviour
{
    public GameObject Inim;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 12f, ForceMode2D.Impulse);
            Inim.GetComponent<Inim>().Dead();
            Destroy(gameObject);

        }

    }
}
