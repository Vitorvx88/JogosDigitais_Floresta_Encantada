using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaBos : MonoBehaviour
{
    private float Alav;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        Alav = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Alav == 3)
        {
            gameObject.SetActive(false);
        }
    }
  public void  Alavancas()
    {
        Alav++;
    }
}
