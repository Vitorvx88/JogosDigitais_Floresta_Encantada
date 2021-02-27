using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextosCine : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Explorador;
    public GameObject Jogador;
    public GameObject joia;
    private float tempo;
    public GameObject texto1;
    public GameObject Imagem;
    public GameObject texto3;
    public string Level;

    void Start()
    {
        tempo = 0;
        texto1.SetActive(false);
        Imagem.SetActive(false);
        texto3.SetActive(false);
        Jogador.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;
        if (tempo >= 8)
        {
            texto1.SetActive(true);

        }
        if (tempo >= 17f)
        {
            texto1.SetActive(false);
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
            texto3.SetActive(true);
        }
        if (tempo >= 31)
        {
            texto3.SetActive(false);
        }
        if (tempo >= 40)
        {
            SceneManager.LoadScene(Level);
        }

    }
}
