using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string cena;
    public GameObject KEYS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void iniciarJogo()
    {
        SceneManager.LoadScene(cena);
        
    }
    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");

    }
    public void iniciar(string lvl)
    {
        SceneManager.LoadScene(lvl);

    }

    public void KeysOn()
    {
        KEYS.SetActive(true);
    }

    public void KeysOFF()
    {
        KEYS.SetActive(false);
    }
    public void sairJogo()
    {
       // UnityEditor.EditorApplication.isPlaying = false;
       Application.Quit();
    }
}
