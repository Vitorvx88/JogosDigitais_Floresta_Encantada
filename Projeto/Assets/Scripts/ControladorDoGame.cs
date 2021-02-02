using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorDoGame : MonoBehaviour
{
    public int pontuacaoTotal;
    public int pontuacaoEstrela;
    public static ControladorDoGame istancia;
    public Text scoreText;
    public Text scoreEstrela;
    public GameObject GameOver;

    private int Pontos;
    // Start is called before the first frame update 
    void Start()
    {
        pontuacaoEstrela = 10;
        istancia = this;
        atualizarEstrelas();
    }
    public void atualizarPoints()
    {
        scoreText.text = pontuacaoTotal.ToString();
    }
    public void atualizarEstrelas()
    {
        scoreEstrela.text = pontuacaoEstrela.ToString();
    }
    public void AtivarGameOver()
    {

        GameOver.SetActive(true);
        Cursor.visible = true;
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
    public void attEstrela(int pontos)
    {
        this.pontuacaoEstrela = pontos;
        scoreEstrela.text = pontuacaoEstrela.ToString();


    }
    public void ReceberPontos(int pontos)
    {
        this.pontuacaoTotal += pontos;
        scoreText.text = pontuacaoTotal.ToString();
    }

}
