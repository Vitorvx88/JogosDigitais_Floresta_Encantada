﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Jogador")]
    public float ForcaPulo;
    public float Velocidade;
    private Rigidbody2D rig;
    private Animator anim;
    private bool emPulo;
    private bool puloDuplo;
    private bool pause;
    private bool menu;
    public float correr;
    private float aux;
    private float aux2;
    private float aux3;
    private CharacterController ColliderPlayer;
    private string cenaAtual;
    private bool agachado;

    [Header("Vidas")]
    public GameObject coracao1;
    public GameObject coracao2;
    public GameObject coracao3;
    private int vidas;
    private float tempo;
    private bool isDano;
    private float cronometro;
    private bool Cora1;
    private bool Cora2;





    [Header("Painel e Menu")]
    public GameObject pausePainel;
    public string cena;

    void Awake()
    {
        cronometro = 0f;
        isDano = false;
        cenaAtual = SceneManager.GetActiveScene().name;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cora1 = true;
        Cora2 = true;


        Time.timeScale = 1f;
        aux2 = ForcaPulo;
        aux = Velocidade;
        anim = gameObject.GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        // Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            Mover();
            Pular();
            Correr();
            Abaixar();
            SalvarPosicao();


            tempo += Time.deltaTime;
            if (isDano == true)
            {
                cronometro += Time.deltaTime;
                if (cronometro >= 1f)
                {
                    anim.SetBool("Dano", false);

                    isDano = false;
                    cronometro = 0f;
                }
            }
        }

        //pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            pauseGame();
        }
    }
    void Mover()
    {
        // float movimento = Input.GetAxis("Horizontal");
        // rig.velocity = new Vector2(movimento * Velocidade, rig.velocity.y);

        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movimento * Time.deltaTime * Velocidade;
        if (Input.GetAxis("Horizontal") > 0f)
        {

            anim.SetBool("Andando", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {

            anim.SetBool("Andando", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (Input.GetAxis("Horizontal") == 0f)
        {

            anim.SetBool("Andando", false);
        }

    }

    void Pular()
    {


        if (Input.GetButtonDown("Jump") && agachado)
        {
            if (!emPulo)
            {
                rig.AddForce(new Vector2(0f, ForcaPulo * 1.2f), ForceMode2D.Impulse);
                puloDuplo = true;

                anim.SetBool("Pulando", true);

            }
            else
            {
                if (puloDuplo)
                {
                    rig.AddForce(new Vector2(0f, (ForcaPulo - 2) * 0.5f), ForceMode2D.Impulse);
                    puloDuplo = false;
                }
            }

        }
    }
    void Correr()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Velocidade = correr;

            anim.SetBool("Correndo", true);

        }
        else
        {

            anim.SetBool("Correndo", false);

            Velocidade = aux;
        }
    }
    void Abaixar()
    {
        Vector3 novaPosicao = transform.position;
        if (!emPulo)
        {
            if (Input.GetKey(KeyCode.X))
            {
                novaPosicao.x = PlayerPrefs.GetFloat(cenaAtual + "X", transform.position.x);
                transform.position = novaPosicao;

                anim.SetBool("Abaixar", true);

                agachado = false;
            }
            if (Input.GetKey(KeyCode.X) == false)
            {

                anim.SetBool("Abaixar", false);
                agachado = true;
            }
        }
    }
    void pauseGame()
    {
        if (pause)
        {
            pausePainel.SetActive(false);
            Time.timeScale = 1f;
            pause = false;

            Cursor.visible = false;
        }
        else
        {
            pausePainel.SetActive(true);
            Time.timeScale = 0f;
            pause = true;

            Cursor.visible = true;
        }
    }
    void Menu()
    {
        if (menu)
        {
            pausePainel.SetActive(false);
            Time.timeScale = 1f;
            pause = false;
            SceneManager.LoadScene("Menu");

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            emPulo = false;
            anim.SetBool("Pulando", false);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            emPulo = true;
        }
        if (collision.gameObject.tag == "Pass" || collision.gameObject.tag == "Sap")
        {

            if (tempo >= 1f)
            {
                vidas++;
                tempo = 0f;

                if (vidas == 1)
                {
                    coracao1.SetActive(false);
                    anim.SetBool("Dano", true);
                    isDano = true;
                    Cora1 = false;
                }
                if (vidas == 2)
                {
                    coracao2.SetActive(false);
                    anim.SetBool("Dano", true);
                    isDano = true;
                    Cora2 = false;
                }
                if (vidas == 3)
                {
                    coracao3.SetActive(false);
                    ControladorDoGame.istancia.AtivarGameOver();
                    Destroy(gameObject);
                }

            }
            

        }


    }
    public void ComprarVida()
    {
        if (ControladorDoGame.istancia.pontuacaoTotal >= 10)
        {


            if (Cora1 == false)
            {
                if (Cora2 == false)
                {
                    coracao2.SetActive(true);
                    Cora2 = true;
                    vidas = vidas - 1;
                    ControladorDoGame.istancia.pontuacaoTotal = ControladorDoGame.istancia.pontuacaoTotal - 10;
                    ControladorDoGame.istancia.att(ControladorDoGame.istancia.pontuacaoTotal);
                }
                else
                {
                    coracao1.SetActive(true);
                    Cora1 = true;
                    vidas = vidas - 1;
                    ControladorDoGame.istancia.pontuacaoTotal = ControladorDoGame.istancia.pontuacaoTotal - 10;
                    ControladorDoGame.istancia.att(ControladorDoGame.istancia.pontuacaoTotal);
                }

            }
            if (Cora2 == false)
            {
                coracao2.SetActive(true);
                Cora2 = true;
                vidas = vidas - 1;
                ControladorDoGame.istancia.pontuacaoTotal = ControladorDoGame.istancia.pontuacaoTotal - 10;
                ControladorDoGame.istancia.att(ControladorDoGame.istancia.pontuacaoTotal);
            }
            
        }
    }

    void SalvarPosicao()
    {
        PlayerPrefs.SetFloat(cenaAtual + "X", transform.position.x);
        //PlayerPrefs.SetFloat(cenaAtual + "Y", transform.position.y);
    }
    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
