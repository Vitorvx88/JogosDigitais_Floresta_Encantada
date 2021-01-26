using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool pause;
    [Header("Painel e Menu")]
    public GameObject pausePainel;
    public string cena;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }
    }
    void pauseGame()
    {


        if (pause)
        {
            pausePainel.SetActive(false);
            Time.timeScale = 1f;
            pause = false;
            // Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }
        else
        {

            pausePainel.SetActive(true);
            Time.timeScale = 0f;
            pause = true;
            // Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;

        }
    }
}
