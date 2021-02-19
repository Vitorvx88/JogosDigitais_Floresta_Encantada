using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarAvisoAlavanca : MonoBehaviour
{
    public GameObject Aviso;
    private bool ativar;
    private float tempo,unica;

    void Start()
    {
       
        ativar = false;
        unica = PlayerPrefs.GetInt("Unica");
        tempo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(ativar && unica==1)
        {
            tempo += Time.deltaTime;
            Aviso.SetActive(true);
            if (tempo >= 10f)
            {
                Aviso.SetActive(false);
                unica = 0;
            }

        }
    }

    public void UnicaVez()
    {
        ativar = true;
    }
    
}
