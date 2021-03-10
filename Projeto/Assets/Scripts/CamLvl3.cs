using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLvl3 : MonoBehaviour
{
    public float velocidade = 0.15f;
    private Transform pivor;
    public GameObject jogador;
    public bool maxMin;
    private float xMin = 1.58f;
    private float yMin = -3.02f;
    private float xMax = 470.6f;
    private float yMax = 56.36f;
    private float Local;
    // Start is called before the first frame update
    void Start()
    {

       
        pivor = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
    
        

        if (pivor)
        {
           //Debug.Log(jogador.GetComponent<Player>().pegar());
           // Debug.Log(xMin);
            TestXMIn();
            transform.position = (Vector3.Lerp(transform.position, pivor.position, velocidade) + new Vector3(0, 0, -4));
            if (maxMin)
            {
                transform.position = new Vector3(Mathf.Clamp(pivor.position.x, xMin, xMax), Mathf.Clamp(pivor.position.y, yMin, yMax), -4);

            }
        }
    }
    void TestXMIn()
    {
           if (jogador.GetComponent<Player>().pegar())
           {
               xMin = 118.26f;
           }
           else
           {
               xMin = 1.58f;
           }
            
    }
}
