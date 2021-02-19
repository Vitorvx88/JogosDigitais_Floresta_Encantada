using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel_2 : MonoBehaviour
{
    public string Level;
    public GameObject Imagem;
    private float tempo;
    private bool Go;

    // Start is called before the first frame update
    private void Start()
    {
        tempo = 0;
        Go = false;
    }
    private void Update()
    {
        if (Go)
        {
            tempo += Time.deltaTime;
            Imagem.SetActive(true);
            if (tempo >= 2)
            {
                Imagem.SetActive(false);
                PlayerPrefs.SetInt("kkj_Lvl2", 4);

                
                SceneManager.LoadScene(Level);

            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Go = true;
        }
    }
}
