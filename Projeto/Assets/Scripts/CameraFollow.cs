using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float velocidade = 0.15f;
    private Transform pivor;
    public bool maxMin;
    private float xMin= 0.2f;
    private float yMin= 0.80f;
    private float xMax= 423.74f;
    private float yMax= 43.59f;
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
            transform.position = (Vector3.Lerp(transform.position, pivor.position, velocidade) + new Vector3(0,0, -4));
            if (maxMin)
            {
                transform.position = new Vector3(Mathf.Clamp(pivor.position.x, xMin, xMax), Mathf.Clamp(pivor.position.y, yMin,yMax), -4);
                    
            }
        }   
    }
}
