using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cereja : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D Colisao;
    public GameObject coletar;
    public int pontuacao;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Colisao = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame

  void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Player")
        {  
            sr.enabled = false;
            //colisao.enabled = false;
            coletar.SetActive(true);
            ControladorDoGame.istancia.pontuacaoTotal += pontuacao;
            ControladorDoGame.istancia.atualizarPoints();
            Destroy(gameObject, 0.3f);

        }
    }
}
