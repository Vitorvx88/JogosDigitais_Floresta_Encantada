using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loja : MonoBehaviour
{
    public GameObject LojaCompas;
    // Start is called before the first frame update
    private bool isDano=false;
    private float cronometro=0f;
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (isDano == true)
        {
            cronometro += Time.deltaTime;
            if (cronometro >= 8f)
            {
                LojaCompas.SetActive(false);
                isDano = false;
                cronometro = 0f;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LojaCompas.SetActive(true);
            isDano = true;
            
        }
       
            
    }


}
