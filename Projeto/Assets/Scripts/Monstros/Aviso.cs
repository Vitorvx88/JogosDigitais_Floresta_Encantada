using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aviso : MonoBehaviour
{
    public GameObject AvisoBos;
    private float Tempo;
    private bool Vrf;
    // Start is called before the first frame update
    void Start()
    {
        Vrf = false;
        Tempo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vrf)
        {
            Tempo += Time.deltaTime;
            AvisoBos.SetActive(true);
            if (Tempo >= 12)
            {
                AvisoBos.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vrf = true;
    }
}
