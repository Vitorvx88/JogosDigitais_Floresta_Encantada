using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Jogador")]

    public static Player istancia;
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
    private bool NaoMoverParado;
    private string cenaAtual;
    private bool agachado;
    private float movi;
    private float TempoDash;


    [Header("Vidas")]
    public GameObject coracao1;
    public GameObject coracao2;
    public GameObject coracao3;
    public GameObject coracao4;
    private int vidas;
    private float tempo;
    private bool isDano;
    private float cronometro;
    private bool Cora1;
    private bool Cora2;
    private bool cora3;

    [Header("Atirar")]
    public GameObject Tiro;
    public Transform PivorDoTiro;
    public float velocidade;
    public float ProxTiro;
    private float PFv;



    [Header("Painel e Menu")]
    public GameObject pausePainel;
    public string cena;

    [Header("Loja")]
    public GameObject Loja;

    [Header("Caverna")]
    public GameObject Entrada;

    [Header("Assistencia")]
    public GameObject Assist;
    public GameObject Texto;
    private float TempLocked;
    private bool TempLockedIs;
    private bool unica;

    void Awake()
    {
        // Cursor.visible = false;
        cronometro = 0f;
        TempLocked = 0f;
        isDano = false;
        unica = true;
        cenaAtual = SceneManager.GetActiveScene().name;
        Texto.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        Cora1 = true;
        Cora2 = true;
        PFv = 2;
        NaoMoverParado = true;
        Entrada.SetActive(true);
       // 
        TempLockedIs = false;

        Time.timeScale = 1f;
        aux2 = ForcaPulo;
        aux = Velocidade;
        anim = gameObject.GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        // Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

    }
    void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {

            Pular();
            if (Input.GetKey(KeyCode.X))
            {
                movi = 0;
                NaoMoverParado = false;
            }
            else
            {
                NaoMoverParado = true;
                movi = Input.GetAxis("Horizontal");
            }


            if (NaoMoverParado)
            {
                Mover(movi);
            }
            else
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
                }


                if (Input.GetAxis("Horizontal") < 0)
                {
                    transform.eulerAngles = new Vector3(0f, 180f, 0f);
                }
            }
            Correr();
            Abaixar();
            SalvarPosicao();
            Morte();

            TempoDash += Time.deltaTime;
            tempo += Time.deltaTime;
            PFv += Time.deltaTime;


            if (Input.GetKey(KeyCode.Z) && PFv >= ProxTiro && agachado)
            {
                if (ControladorDoGame.istancia.pontuacaoEstrela > 0)
                {
                    anim.SetBool("Atirar", true);
                    Atirar();
                }
            }
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
            if (PlayerPrefs.GetFloat(cenaAtual + "X", transform.position.x) >= 214.2959 && PlayerPrefs.GetFloat(cenaAtual + "X", transform.position.x) <= 218.6947f)
            {
                if (Input.GetKey(KeyCode.L))
                {
                    Loja.SetActive(true);
                    Cursor.visible = true;
                }

            }
            else
            {
                Loja.SetActive(false);
                Cursor.visible = false;
            }

            if (PlayerPrefs.GetFloat(cenaAtual + "X", transform.position.x) >= 214.2959 && PlayerPrefs.GetFloat(cenaAtual + "X", transform.position.x) <= 218.6947f)
            {
                if (Input.GetKey(KeyCode.K))
                {
                    Loja.SetActive(false);
                    Cursor.visible = false;
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }
        if (TempLockedIs && unica)
        {
            TempLocked +=Time.deltaTime;
            Texto.SetActive(true);
            if (TempLocked >= 18f)
            {
                Assist.SetActive(false);
                TempLockedIs = false;
                Texto.SetActive(false);
                TempLocked = 0f;
                unica = false;
            }
        }

    }
     void Dash()
    {
        Vector3 novaPosicao = transform.position;
        novaPosicao.x = PlayerPrefs.GetFloat(cenaAtual + "X", transform.position.x);
        transform.position = novaPosicao;

    }

    void Mover(float movi)
    {
        // Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        // transform.position += movimento * Time.deltaTime * Velocidade;
        // Debug.Log(movi);

        rig.velocity = new Vector2(movi * Velocidade, rig.velocity.y);

        if (movi > 0f)
        {

            anim.SetBool("Andando", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (movi < 0f)
        {

            anim.SetBool("Andando", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (movi == 0f)
        {

            anim.SetBool("Andando", false);
        }

    }
    public void Morte()
    {
        if (PlayerPrefs.GetFloat(cenaAtual + "Y", transform.position.y) <= -10)
        {
            ControladorDoGame.istancia.AtivarGameOver();
            Temporizador.Stop();

            coracao2.SetActive(false);
            coracao1.SetActive(false);
            coracao3.SetActive(false);
            Destroy(gameObject);
        }
    }
    void Atirar()
    {
        PFv = 0f;
        GameObject project = Instantiate(Tiro, PivorDoTiro.position, PivorDoTiro.rotation);
        ControladorDoGame.istancia.pontuacaoEstrela = ControladorDoGame.istancia.pontuacaoEstrela - 1;
        ControladorDoGame.istancia.attEstrela(ControladorDoGame.istancia.pontuacaoEstrela);
        anim.SetBool("Atirar", false);
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
         if(collision.gameObject.tag == "Bos")
        {
            TomarDano();
        }
       /* if (collision.gameObject.tag == "Hit")
        {
            

        }*/
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            emPulo = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Entrada")
        {
            Entrada.SetActive(false);
        }
        if (collision.gameObject.tag == "Aviso")
        {
            TempLockedIs = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Saida")
        {
            Entrada.SetActive(true);
        }
       
    }

    public void VamosPular()
    {
        anim.SetBool("Abaixar", true);
    }
    public void TomarDano()
    {
      //  Debug.Log("algo");
        if (tempo >= 1f)
        {
           // Debug.Log("algo2");
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
                anim.SetBool("Dano", true);
                isDano = true;
                cora3 = false;
            }
                if (vidas == 4)
            {
                coracao4.SetActive(false);
                ControladorDoGame.istancia.AtivarGameOver();
                Temporizador.Stop();
                Destroy(gameObject);
            }

        }
    }
    public void ComprarVida()
    {
        if (ControladorDoGame.istancia.pontuacaoTotal >= 110)
        {


            if (Cora1 == false)
            {
                if (Cora2 == false)
                {
                    if (cora3 == false)
                    {
                        coracao3.SetActive(true);
                        cora3 = true;
                        vidas = vidas - 1;
                        ControladorDoGame.istancia.pontuacaoTotal = ControladorDoGame.istancia.pontuacaoTotal - 120;
                        ControladorDoGame.istancia.att(ControladorDoGame.istancia.pontuacaoTotal);
                    }else
                    {
                        coracao2.SetActive(true);
                        Cora2 = true;
                        vidas = vidas - 1;
                        ControladorDoGame.istancia.pontuacaoTotal = ControladorDoGame.istancia.pontuacaoTotal - 120;
                        ControladorDoGame.istancia.att(ControladorDoGame.istancia.pontuacaoTotal);
                    }
                    
                }
                else
                {
                    coracao1.SetActive(true);
                    Cora1 = true;
                    vidas = vidas - 1;
                    ControladorDoGame.istancia.pontuacaoTotal = ControladorDoGame.istancia.pontuacaoTotal - 120;
                    ControladorDoGame.istancia.att(ControladorDoGame.istancia.pontuacaoTotal);
                }

            }
        }
    }
    public void ComprarEstrela()
    {
        if (ControladorDoGame.istancia.pontuacaoTotal >= 110)
        {
            ControladorDoGame.istancia.pontuacaoEstrela += +1;
            ControladorDoGame.istancia.attEstrela(ControladorDoGame.istancia.pontuacaoEstrela);
            ControladorDoGame.istancia.pontuacaoTotal = ControladorDoGame.istancia.pontuacaoTotal - 120;
            ControladorDoGame.istancia.att(ControladorDoGame.istancia.pontuacaoTotal);
        }
    }

    void SalvarPosicao()
    {
        PlayerPrefs.SetFloat(cenaAtual + "X", transform.position.x);
        PlayerPrefs.SetFloat(cenaAtual + "Y", transform.position.y);
    }
    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
