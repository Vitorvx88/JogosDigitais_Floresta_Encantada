using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorDoGame : MonoBehaviour
{
    public int pontuacaoTotal;
    public static ControladorDoGame istancia;
    public Text scoreText;
    public GameObject GameOver;
    // Start is called before the first frame update 
    void Start()
    {
        istancia = this;
    }
    public void atualizarPoints()
    {
        scoreText.text = pontuacaoTotal.ToString();
    }
    public void AtivarGameOver()
    {
        GameOver.SetActive(true);
    }
    public void reniciarCena(string cene)
    {
        SceneManager.LoadScene(cene);
    }
    public void att(int pontos)
    {
        this.pontuacaoTotal = pontos;
        scoreText.text = pontuacaoTotal.ToString();
    }
}
