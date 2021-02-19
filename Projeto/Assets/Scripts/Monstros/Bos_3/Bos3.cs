using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bos3 : MonoBehaviour
{
    [Header("Atirar")]
    public GameObject Tiro;
    public Transform PivorDoTiro;
    public float tempoPRoxTiro;
    public GameObject Shadown;
    private float PFv;
    private bool player;

    [Header("Explorador")]
    public GameObject Ativar1;
    public GameObject Ativar2;

    [Header("Atributos_Basicos")]
    private string cenaAtual;
    public static Bos_1 istancia;
    public float Velocidade;
    private Transform posicaoDoPlayer;
    private Vector2 Test;
    private Animator anim;
    private bool LadoDireito = false;
    public GameObject Jogador;
    private float Vida;
    private bool isDano;
    private float cronometro;
    public GameObject HitDam;
    private bool Isfragil;
    private float TimeHit;
    public GameObject Explodir;
    private bool unica;
    private bool unica1;
    private bool unica2;
    private bool unica3;
    private bool unica4;
    // Start is called before the first frame update
    void Awake()
    {
        cenaAtual = SceneManager.GetActiveScene().name;
    }
    void Start()
    {
        Isfragil = false;

        isDano = false;
        player = false;
        PFv = 2;
        Vida = 80;
        cronometro = 0f;
        HitDam.SetActive(false);
        unica3 = true;
        unica2 = true;
        unica1 = true;
        unica = true;
        unica4 = true;


        posicaoDoPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = gameObject.GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        if (posicaoDoPlayer.gameObject != null && Isfragil == false)
        {

            if (isDano == true)
            {
                cronometro += Time.deltaTime;
                if (cronometro >= 1.2f)
                {
                    //anim.SetBool("Dano", false);
                    isDano = false;
                    cronometro = 0f;
                }
            }

            if (PlayerPrefs.GetFloat(cenaAtual + "X", transform.position.x) >= 110.68f && PlayerPrefs.GetFloat(cenaAtual + "X", transform.position.x) <= 127.06f)
            {
                PFv += Time.deltaTime;
                anim.SetBool("Andando", true);
                Test = new Vector2(posicaoDoPlayer.position.x, transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, Test, Velocidade * Time.deltaTime);
                player = true;
                if (PFv >= tempoPRoxTiro && player)
                {

                    Atirar();
                    PFv = 0;
                }
            }
            else
            {
                anim.SetBool("Andando", false);
            }
            if ((transform.position.x - posicaoDoPlayer.position.x) > 0 && !LadoDireito)
            {
                Vire();

                PivorDoTiro.transform.eulerAngles = new Vector3(0, 0, 180);
            }
            if ((transform.position.x - posicaoDoPlayer.position.x) < 0 && LadoDireito)
            {
                Vire();
                PivorDoTiro.transform.eulerAngles = new Vector3(0, 0, 0);
            }




        }
        unica3 = true;
        unica2 = true;
        unica1 = true;
        unica = true;
        unica4 = true;
        if (Isfragil)
        {
            TimeHit += Time.deltaTime;
            if (TimeHit>=0.1 && unica)
            {
                anim.SetBool("Vull", true);
                HitDam.SetActive(true);
                unica = false;
            }
            
            if (TimeHit >= 2f && unica1)
            { 
                HitDam.SetActive(false);
                unica1 = false;


            }
            if (TimeHit >= 2.5f && unica2)
            {
                HitDam.SetActive(false);
                anim.SetBool("Vull", false);
                anim.SetBool("Explodir", true);
                unica2 = false;
            }

            if (TimeHit >= 3.5f && unica3)
            {
                anim.SetBool("Explodir", false);
                Explodir.SetActive(true);
                unica3= false;

            }
            if (TimeHit >= 4.5f && unica4)
            {
         
                Explodir.SetActive(false);
                TimeHit = 0f;
                unica4 = false;
                Isfragil = false;
                
            }
        }

    }
    void SalvarPosicao()
    {
        PlayerPrefs.SetFloat(cenaAtual + "X", transform.position.x);
    }
    void Vire()
    {

        LadoDireito = !LadoDireito;
        Vector2 novoScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        transform.localScale = novoScale;

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 13f, ForceMode2D.Impulse);
            Jogador.GetComponent<Player>().TomarDano();
        }
        if (col.gameObject.tag == "Dead")
        {
            Isfragil = true;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dead")
        {
            Isfragil = true;
        }
    }
    void Atirar()
    {

        GameObject project = Instantiate(Tiro, PivorDoTiro.position, PivorDoTiro.rotation);

    }
    public void PerderVida(float dano)
    {
        // anim.SetBool("Dano", true);
        Vida += -dano;
        checarVida();
        isDano = true;
    }
    void checarVida()
    {
        if (Vida <= 0)
        {
            // anim.SetBool("Dano", false);
            Ativar1.SetActive(false);
            Ativar2.SetActive(false);
            anim.SetBool("Andando", false);
            ControladorDoGame.istancia.ReceberPontos(300);
            ControladorDoGame.istancia.atualizarPoints();
            Jogador.GetComponent<Player>().ReceberKey();
            Debug.Log("Recebeu a chave!");
            anim.SetTrigger("Dead");
            Destroy(gameObject, 0.80f);
        }
    }
    public bool vidaB()
    {
        if (this.Vida <= 0)
        {
            return false;
        }
        else
            return true;
    }
}
