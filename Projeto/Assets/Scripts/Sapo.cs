using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapo : MonoBehaviour
{
    private Rigidbody2D rig;
    // Start is called before the first frame update


    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 7, ForceMode2D.Impulse);


        }
        if (collision.gameObject.tag == "Dead")
        {
            
            Destroy(gameObject);
        }
        
    }
}
