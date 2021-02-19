using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
   
    }
    public void Resetar()
    {
        PlayerPrefs.SetInt("kkj_Lvl2", 5);
        PlayerPrefs.SetInt("kkj", 2);
        PlayerPrefs.SetInt("kkj_Lvl3", 5);
        PlayerPrefs.SetInt("pontuacao", 0);
        PlayerPrefs.SetInt("pontuacaoEstrela", 5);
        PlayerPrefs.SetFloat("tempoS", 0f);
        PlayerPrefs.SetFloat("tempoM", 0f);

        SceneManager.LoadScene("Level 1");
    }
}
