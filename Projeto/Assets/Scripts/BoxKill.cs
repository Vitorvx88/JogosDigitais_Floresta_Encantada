using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxKill : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sapo;
    public BoxCollider2D BoxCollider2D;
    private Animator anim;
    public int pass;
    public int sap;

    void Start()
    {
        anim = GetComponent<Animator>();

    }
    private void Update()
    {
     
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            ControladorDoGame.istancia.pontuacaoTotal = ControladorDoGame.istancia.pontuacaoTotal + pass + sap;
            ControladorDoGame.istancia.att(ControladorDoGame.istancia.pontuacaoTotal);
            Destroy(sapo,0.40f);
            Destroy(gameObject,0.50f);
        }
    }
}
