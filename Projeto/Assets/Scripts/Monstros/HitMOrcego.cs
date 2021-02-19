using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMOrcego : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Morcergo;

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Debug.Log("Bom dia!");
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 15f, ForceMode2D.Impulse);
            Morcergo.GetComponent<Morcego>().Dead();
        }

    }
}
