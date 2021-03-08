using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextosCine : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Explorador;
    public GameObject Jogador;
    public GameObject joia;
    
    public GameObject dialog;
    public GameObject dialog2;
    public GameObject Imagem;
    public Image profile;
    private float tempo;
    public string Level;


    void Start()
    {
        tempo = 0;

        Jogador.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;
        if (tempo >= 8)
        {
          
          dialog.SetActive(true);
          



        }
        if (tempo >= 17f)
        {
            dialog.SetActive(false);
            Imagem.SetActive(true);

        }
        if (tempo >= 18f)
        {
            Explorador.SetActive(false);
            joia.SetActive(false);
            Imagem.SetActive(false);
        }
        if (tempo >= 19)
        {
            Jogador.SetActive(true);
           
            dialog2.SetActive(true);
        }
        if (tempo >= 31)
        {
            dialog2.SetActive(false);
        }
        if (tempo >= 40)
        {
            SceneManager.LoadScene(Level);
        }

    }

}
