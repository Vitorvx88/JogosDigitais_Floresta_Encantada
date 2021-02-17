using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlavancaBos : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PortaBos;
    public GameObject On;
    private bool ON,UnicaVez;


    private void Start()
    {
        ON = false;
        UnicaVez = true;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && UnicaVez && ON)
        {
            PortaBos.GetComponent<PortaBos>().Alavancas();
            gameObject.SetActive(false);
            On.SetActive(true);
            UnicaVez = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ON = true;
        }
    }


}
