﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ativar : MonoBehaviour {
    public GameObject PreFab;
    public GameObject Espinhos;


    private bool UnicaVez;
    private bool ON;
    void Start()
    {
        UnicaVez = true;
        ON = false;
    }

    // Update is called once per frame
    void Update()
    {       
        if (UnicaVez && ON)
        {
            Invoke("SpawnObjeto",0.2f);
          
            UnicaVez = false;
            ON = false;
        }
    }

    void SpawnObjeto()
    {
        Instantiate(PreFab, new Vector3(1.27f, 1.258717f, 0), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        ON = true;
        if(collision.gameObject.tag == "Player")
        {

            Espinhos.SetActive(false);
        }
    }


}