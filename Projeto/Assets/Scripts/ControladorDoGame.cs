using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorDoGame : MonoBehaviour
{
    public int pontuacaoTotal;
    public static ControladorDoGame istancia;
    public Text scoreText;
    // Start is called before the first frame update 
    void Start()
    {
        istancia = this;
    }
    public void atualizarPoints()
    {
        scoreText.text = pontuacaoTotal.ToString();
    }
}
