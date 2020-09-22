using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisoesCarro : MonoBehaviour
{
    public GameObject scripts;
    public GameObject flash;
    public GameObject crash;
    public GameObject camera;
    float speed;
    public float lucro;
    byte multa = 0;
    private int danoPorColisao;
    float vidaDoPlayer;
    public int quantasVezesPassouNoSemaforo = 0;
    public int quantasVezesbateu = 0;

    void Update()
    {
        vidaDoPlayer = barraDevidaEProgresao.vidaDoPlayer;
        speed = solo.speed;

        if (vidaDoPlayer <= 0)
        {
            danoPorColisao = 0;
            barraDevidaEProgresao.vidaDoPlayer = 0;
        }
        else if (speed < 100 && vidaDoPlayer > 0)
        {
            danoPorColisao = 10;

        }
        else if (speed > 100 && speed < 200 && vidaDoPlayer > 0)
        {
            danoPorColisao = 20;

        }
        else if (speed > 200 && speed < 300 && vidaDoPlayer > 0)
        {
            danoPorColisao = 30;

        }
        else if (speed > 300 && speed < 400 && vidaDoPlayer > 0)
        {
            danoPorColisao = 40;

        }
        else if (speed > 400 && speed < 500 && vidaDoPlayer > 0)
        {
            danoPorColisao = 50;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("carroIndo"))
        {
            camera.GetComponent<camera>().empurraCamera();
            solo.parando = true;
            barraDevidaEProgresao.vidaDoPlayer -= danoPorColisao;
            Instantiate(crash, new Vector3(transform.position.x, 20.0f, 570.0f), transform.rotation);
            Destroy(collision.gameObject, 0.1f);
            if (instanciadorCarroDireita.QuantidadeDeCarrosNaDireita >= 1) instanciadorCarroDireita.QuantidadeDeCarrosNaDireita--;

            lucro -= 50.47f;
            StartCoroutine(aguardaParaAndar());
            quantasVezesbateu++;

        }
        else if (collision.gameObject.CompareTag("carroVindo"))
        {
            camera.GetComponent<camera>().empurraCamera();
            solo.parando = true;
            barraDevidaEProgresao.vidaDoPlayer -= danoPorColisao;
            Instantiate(crash, new Vector3(transform.position.x, 20.0f, 570.0f), transform.rotation);
            Destroy(collision.gameObject, 0.1f);
            if (instanciadorCarrosEsquerda.QuantidadeDeCarrosNaEsquerda > 0) instanciadorCarrosEsquerda.QuantidadeDeCarrosNaEsquerda--;

            lucro -= 50.47f;
            StartCoroutine(aguardaParaAndar());
            quantasVezesbateu++;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("semaforo"))
        {
            Instantiate(flash, new Vector3(transform.position.x, 26.0f, 572.0f), transform.rotation);

            quantasVezesPassouNoSemaforo++;

            if (lucro < 0)
            {
                lucro = 0;
            }
            else
            {
                lucro -= 293.47f;
            }
            multa += 1;
        }
        if (other.gameObject.CompareTag("chegada"))
        {
            scripts.GetComponent<acoes>().gangouPartida();
        }
    }

    IEnumerator aguardaParaAndar()
    {
        yield return new WaitForSeconds(0.6f);
        solo.parando = false;
    }

}
