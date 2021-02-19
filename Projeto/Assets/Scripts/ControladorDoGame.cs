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
    public GameObject GameOverBos;
    public GameObject jogador;
    private float tempoS;
    private float tempoM;
    public bool ativarCheckPoint;
    public GameObject monstros;



    private int Pontos;
    // Start is called before the first frame update 
    void Start()
    {
   
        atualizarPoints();
        atualizarEstrelas();
        pontuacaoEstrela = 5;
        istancia = this;
       
        

        if (PlayerPrefs.GetInt("kkj") == 1|| PlayerPrefs.GetInt("kkj_Lvl2") == 3)
        {
          
            this.pontuacaoTotal = PlayerPrefs.GetInt("pontuacao");
            this.pontuacaoEstrela = PlayerPrefs.GetInt("pontuacaoEstrela");
            this.tempoS = PlayerPrefs.GetFloat("tempoS");
            this.tempoM = PlayerPrefs.GetFloat("tempoM");

            atualizarPoints();
            atualizarEstrelas();

        }
        if (pontuacaoTotal > 0 )
        {
            monstros.SetActive(true);
        }
        else
            monstros.SetActive(false);

        {

        }
    }
    private void Update()
    {
        //salvar();
    }
    public void resetarPontos()
    {
        //Debug.Log("res");
        PlayerPrefs.SetInt("pontuacao", 0);
        PlayerPrefs.SetInt("pontuacaoEstrela", 5);
        PlayerPrefs.SetFloat("tempoS", 0f);
        PlayerPrefs.SetFloat("tempoM", 0f);
    }
    public void salvar()
    {
        PlayerPrefs.SetInt("pontuacao", this.pontuacaoTotal);
        PlayerPrefs.SetInt("pontuacaoEstrela", this.pontuacaoEstrela);
        PlayerPrefs.SetFloat("tempoS", this.tempoS);
        PlayerPrefs.SetFloat("tempoM", this.tempoM);
    }
    public void receberTempo( float tempoS, float tempoM)
    {
        this.tempoS = tempoS;
        this.tempoM = tempoM;
    }
    public float enviarTempoS()
    {
        return tempoS;
    } 
    public float enviarTempoM()
    {
        return tempoM;
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
        
       // Debug.Log(PlayerPrefs.GetInt("kkj"));
        GameOver.SetActive(true);
        Cursor.visible = true;
        ControladorDoGame.istancia.resetarPontos();
        //Debug.Log("morreu sem ser pro boss 2");
        monstros.SetActive(false);

    }
    public void AtivarGameOverBos()
    {
        //PlayerPrefs.SetInt("kkj", 2);
       // Debug.Log(PlayerPrefs.GetInt("kkj")+" "+"Bos");
        GameOver.SetActive(true);
        Cursor.visible = true;
        
        //Debug.Log("morreu pro boss 2");

    }
    public void receberV()
    {
        ativarCheckPoint = true;
    }
    public bool verificarCheckPoint ()
    {
        return this.ativarCheckPoint;

    }
    public void checkPoint()
    {
        salvar();
    }
    
    public void reniciarCena(string cene)
    {
        monstros.SetActive(true);
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
