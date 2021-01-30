using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapo : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;
    public static Sapo istancia;
    // Start is called before the first frame update
    private void Start()


    {
        anim = GetComponent<Animator>();
    }
    

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 7, ForceMode2D.Impulse);


        }
        if (collision.gameObject.tag == "Dead")
        {
            Dead();
        }
        
    }
    public void Dead()
    {
        anim.SetTrigger("kill");
        Destroy(gameObject, 0.25f);
    }
}
