﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explorador : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}