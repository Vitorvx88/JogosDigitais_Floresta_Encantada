using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passaro : MonoBehaviour
{
    public float VelPass;
    public float moverPass;
    private bool Direita;
    private float tempo;


    // Update is called once per frame
    void Update()
    {
        if (Direita)
        {
            transform.Translate(Vector2.left * VelPass * Time.deltaTime);

        }
        else
        {
            transform.Translate(Vector2.right * VelPass * Time.deltaTime);

        }
        tempo += Time.deltaTime;
        if (tempo >= moverPass)
        {
            Direita = !Direita;
            tempo = 0f;   
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
        }
    }

}
