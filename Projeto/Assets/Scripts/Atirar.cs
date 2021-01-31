using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public float TempoDeVida;
    public int pass;
    public int sap;
    public int rato;
    // Start is called before the first frame update
    void Start()
    {
 
       TempoDeVida = 3f;
       Destroy(gameObject, TempoDeVida);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * 13 * Time.deltaTime*2);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pass"|| collision.gameObject.tag == "Rato"|| collision.gameObject.tag == "Sap")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Testando")
        {
            Destroy(gameObject);
        }

    }
    
}
