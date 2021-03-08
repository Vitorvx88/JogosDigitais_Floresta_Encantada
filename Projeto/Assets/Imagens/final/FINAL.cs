using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FINAL : MonoBehaviour
{
    // Start is called before the first frame update
    private float tempo;
    public GameObject gameOver;
    public GameObject imagem1;
    public GameObject imagem2;
    public GameObject imagem3;
    public GameObject imagem4;
    public GameObject imagem5;
    public GameObject imagem6;
    public GameObject imagem7;
    public GameObject imagem8;
    public GameObject imagem9;
    public GameObject imagem10;
    public GameObject imagem11;
    public GameObject imagem12;
    public GameObject imagem13;
    public GameObject imagem14;
    
    void Start()
    {
        Cursor.visible = false;
        tempo = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;
        if (tempo >= 1)
        {
            imagem1.SetActive(false);
            imagem2.SetActive(true);
        }
        if (tempo >= 2)
        {
            imagem2.SetActive(false);
            imagem3.SetActive(true);
        }
        if (tempo >= 3)
        {
            imagem3.SetActive(false);
            imagem4.SetActive(true);
        }
        if (tempo >= 4)
        {
            imagem3.SetActive(false);
            imagem4.SetActive(true);
        }
        if (tempo >= 5)
        {
            imagem4.SetActive(false);
            imagem5.SetActive(true);
        }
        if (tempo >= 6)
        {
            imagem5.SetActive(false);
            imagem6.SetActive(true);
        }
        if (tempo >= 7)
        {
            imagem6.SetActive(false);
            imagem7.SetActive(true);
        }
        if (tempo >= 8)
        {
            imagem7.SetActive(false);
            imagem8.SetActive(true);
        }
        if (tempo >= 8.5f)
        {
            imagem8.SetActive(false);
            imagem9.SetActive(true);
        }
        if (tempo >= 9)
        {
            imagem9.SetActive(false);
            imagem10.SetActive(true);
        }
        if (tempo >= 9.5f)
        {
            imagem10.SetActive(false);
            imagem11.SetActive(true);
        }
        if (tempo >= 10)
        {
            imagem11.SetActive(false);
            imagem12.SetActive(true);
        }
        if (tempo >= 10.5f)
        {
            imagem12.SetActive(false);
            imagem13.SetActive(true);
        }
        if (tempo >= 11)
        {
            imagem13.SetActive(false);
            imagem14.SetActive(true);
        }
        if (tempo >= 11.5f)
        {
            gameOver.SetActive(true);
            Cursor.visible = true;
        }

    }
}
