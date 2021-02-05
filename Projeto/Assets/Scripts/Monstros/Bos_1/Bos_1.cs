using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bos_1 : MonoBehaviour
{


    [Header("Atirar")]
    public GameObject Tiro;
    public Transform PivorDoTiro;
    public float tempoPRoxTiro;
    public GameObject Shadown;
    private float PFv;
    private bool player;

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
        Vida = 50;
        cronometro = 0f;
        HitDam.SetActive(false);


        posicaoDoPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = gameObject.GetComponent<Animator>();

       
    }

    // Update is called once per frame
    void Update()
    {
        PFv += Time.deltaTime;
        if (posicaoDoPlayer.gameObject != null && Isfragil==false)
        {

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

            if (PlayerPrefs.GetFloat(cenaAtual + "X", transform.position.x) >= 446.15f /*&& PlayerPrefs.GetFloat(cenaAtual + "X", transform.position.x) <= 474.19f*/)
            {
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
            if ((transform.position.x - posicaoDoPlayer.position.x)>0 && !LadoDireito){
                Vire();
                PivorDoTiro.transform.eulerAngles = new Vector3(0, 0, 180);
            }
            if((transform.position.x - posicaoDoPlayer.position.x) < 0 && LadoDireito){
                Vire();
                PivorDoTiro.transform.eulerAngles = new Vector3(0, 0, 0);
            }
           
            


        }
        if (Isfragil)
        {
            TimeHit += Time.deltaTime;
            anim.SetBool("Fragil", true);
            HitDam.SetActive(true);
            if (TimeHit >= 2.5f)
            {
                HitDam.SetActive(false);
                TimeHit = 0f;
                anim.SetBool("Fragil", false);
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
       
        LadoDireito =! LadoDireito;
        Vector2 novoScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        transform.localScale = novoScale;
 
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 13f, ForceMode2D.Impulse);
            Jogador.GetComponent<Player>().TomarDano();
        }
        if (col.gameObject.tag == "Dead")
        {
            PerderVida(7);
        }
     

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Espinhos")
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
        anim.SetBool("Dano", true);
        Vida += -dano;
        checarVida();
        isDano = true;
    }
    void checarVida()
    {
        if (Vida <= 0)
        {
            anim.SetBool("Dano", false);
            anim.SetBool("Andando", false);
            ControladorDoGame.istancia.ReceberPontos(300);
            ControladorDoGame.istancia.atualizarPoints();
            anim.SetTrigger("Morte");
            Destroy(gameObject,0.80f);
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
