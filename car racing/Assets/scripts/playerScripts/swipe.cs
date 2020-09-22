using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipe : MonoBehaviour
{
    public GameObject carro;
    public Animator animator;
    Vector3 posicaofinalDocarro;
    float toqueInicialx;
    float toqueFinalx;
    float posicaoDetoqueSemSwipe;
    int pista;
    public const float pista1 = 18f;
    public const float pista2 = 6f;
    public const float pista3 = -6f;
    public const float pista4 = -18f;
    bool estasegurando;
    public float speed;
    public byte terminouACorrida = 0;

    void Start()
    {

        animator = carro.GetComponent<Animator>();
        int sorteiaFaixa = Random.Range(1, 4);

        if (sorteiaFaixa == 1)
        {
            posicaofinalDocarro = new Vector3(pista1, transform.position.y, 568.0f);
            pista = 1;
        }
        else if (sorteiaFaixa == 2)
        {
            posicaofinalDocarro = new Vector3(pista2, transform.position.y, 568.0f);
            pista = 2;
        }
        else if (sorteiaFaixa == 3)
        {
            posicaofinalDocarro = new Vector3(pista3, transform.position.y, 568.0f);
            pista = 3;
        }
        else if (sorteiaFaixa == 4)
        {
            posicaofinalDocarro = new Vector3(pista4, transform.position.y, 568.0f);
            pista = 4;
        }
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, posicaofinalDocarro, speed * Time.deltaTime);
        // animações
        if (transform.position.x < posicaofinalDocarro.x)
        {
            animator.Play("esquerda");
        }
        else if (transform.position.x > posicaofinalDocarro.x)
        {
            animator.Play("direita");
        }
        else if (transform.position.x == posicaofinalDocarro.x && solo.speed > 0)
        {
            animator.Play("run");
        }
        else
        {
            animator.Play("idle");
        }

        // escolhas de pistas
        if (terminouACorrida == 0)
        {
            Swipe();
        }
        else if (terminouACorrida == 1)
        {
            posicaofinalDocarro = new Vector3(pista4, transform.position.y, 568.0f);

        }
        else if (terminouACorrida == 2)
        {
            posicaofinalDocarro = new Vector3(transform.position.x, transform.position.y, 568.0f);
        }
    }

    void Swipe()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            toqueInicialx = Input.mousePosition.x;
            StartCoroutine(tempoDeToque());

        }


        if (Input.GetButtonUp("Fire1"))
        {
                tempoDeSwipe();

            if (estasegurando == true)
            {
                estasegurando = false;
                solo.parando = false;
            }

        }

    }
    void tempoDeSwipe()
    {


        toqueFinalx = Input.mousePosition.x;



        float distancia = toqueInicialx - toqueFinalx;

        if (distancia > 0.0f && estasegurando == false)
        {
            if (pista > 1)
            {
                if (pista == 4)
                {
                    posicaofinalDocarro = new Vector3(pista3, transform.position.y, 568.0f);
                }
                else if (pista == 3)
                {
                    posicaofinalDocarro = new Vector3(pista2, transform.position.y, 568.0f);
                }
                else if (pista == 2)
                {
                    posicaofinalDocarro = new Vector3(pista1, transform.position.y, 568.0f);
                }
                pista--;
                toqueFinalx = 0;
            }
        }
        else if (distancia < 0.0f && estasegurando == false)
        {
            if (pista < 4)
            {
                if (pista == 1)
                {
                    posicaofinalDocarro = new Vector3(pista2, transform.position.y, 568.0f);
                }
                else if (pista == 2)
                {
                    posicaofinalDocarro = new Vector3(pista3, transform.position.y, 568.0f);
                }
                else if (pista == 3)
                {
                    posicaofinalDocarro = new Vector3(pista4, transform.position.y, 568.0f);
                }
                pista++;
                toqueFinalx = 0;
            }
        }
    }

    IEnumerator tempoDeToque()
    {
        yield return new WaitForSeconds(0.2f);
        posicaoDetoqueSemSwipe = Input.mousePosition.x;

        float valorinicial = toqueInicialx;
        float valorfinal = posicaoDetoqueSemSwipe;
        float distancia = valorinicial - valorfinal;

        if (distancia < 160.0f && distancia > -160.0f && Input.touchCount > 0)
        {
            estasegurando = true;
            solo.parando = true;
        }

    }

  
}
