﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLvl2 : MonoBehaviour
{
    public float velocidade = 0.15f;
    private Transform pivor;
    public bool maxMin;
    private float xMin = 0.2f;
    private float yMin = -2.2f;
    private float xMax = 470.73f;
    private float yMax = 56.36f;
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
            transform.position = (Vector3.Lerp(transform.position, pivor.position, velocidade) + new Vector3(0, 0, -4));
            if (maxMin)
            {
                transform.position = new Vector3(Mathf.Clamp(pivor.position.x, xMin, xMax), Mathf.Clamp(pivor.position.y, yMin, yMax), -4);

            }
        }
    }
}
