using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesativarCair : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Plataforma;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Plataforma.SetActive(true);
        }
    }
}
