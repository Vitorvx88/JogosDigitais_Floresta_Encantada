using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadown_Ball : MonoBehaviour
{
    public float TempoDeVida;
    private bool LadoDireito = false;
    private Transform posicaoDoPlayer;
    public GameObject TEst;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TempoDeVida);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * 2 * Time.deltaTime * 2);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.tag == "Testando"|| collision.gameObject.tag == "Chao")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {

            TEst.GetComponent<Player>().TomarDano();

            Destroy(gameObject);
        }

    }
    void Vire()
    {
        LadoDireito = !LadoDireito;
        Vector2 novoScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        transform.localScale = novoScale;

    }
}
