using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Final : MonoBehaviour
{
    // Start is called before the first frame update
    private float tempo;
    public GameObject texto;
    public GameObject joia;
    public GameObject Progamadores;
    public GameObject imagem1;
    private AudioSource SoundJ;
  

    void Start()
    {
        SoundJ = GetComponent<AudioSource>();
        tempo = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(tempo);

        tempo += Time.deltaTime;
       
        if (tempo >= 12)
        {
            joia.SetActive(true);
        }

        if (tempo >= 13)
        {
            texto.SetActive(true);
        }
        if (tempo >= 21)
        {
            texto.SetActive(false);
        }
        if(tempo >= 22)
        {
            imagem1.SetActive(true);
           
        }
        if (tempo >= 22.5)
        {
            Cursor.visible = true;
            Progamadores.SetActive(true);
        }
        if (tempo >= 510)
        {
            SceneManager.LoadScene("Menu");
        }
 
    }
   
}
