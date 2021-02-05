using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alavanca : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DanoBos;
    public GameObject Espinhos;
    public GameObject Bos;
    private Animator anim;

    private bool UnicaVez;
    private bool ON;
    void Start()
    {
        UnicaVez = true;
        ON = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && UnicaVez&& ON)
        {
            Espinhos.SetActive(false);
            InvokeRepeating("SpawnObjeto", 0, 2);
            anim.SetTrigger("ON");
            UnicaVez = false;
            ON = false;
        }
        if (Bos.GetComponent<Bos_1>().vidaB() == false)
        {
            CancelInvoke("SpawnObjeto");
        }
    }

    void SpawnObjeto()
    {
        Instantiate(DanoBos, new Vector3(440.791f, -0.92f, 0), Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ON = true;
    }
}
