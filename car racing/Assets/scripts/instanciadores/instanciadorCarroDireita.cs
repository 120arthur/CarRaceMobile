using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciadorCarroDireita : MonoBehaviour
{
    public GameObject CarroEsquerda;

    private float speed;
    float velocidadeFinal;
    private float menorValorDoRandomParaInstanciar;
    private float maiorValorDoRandomParaInstanciar;
    private int verificaAVelocidadeParaInstanciar;
    private float maiorValorDoColider = 0f;
    private float menorValorDoColider = 0f;

    [SerializeField]
    private bool podeInstanciarCarroFrente = true;
    private bool podeInstanciarCarroTras = true;
    [SerializeField]
    public static int QuantidadeDeCarrosNaDireita = 0;

    void Start()
    {
        StartCoroutine(aguardaParaInstanciar());
    }

    void Update()
    {
        velocidadeFinal = solo.velocidadeFinal;
        speed = solo.speed;
        ContadordeVelocidadeParaControlarInstanciação();

        switch (verificaAVelocidadeParaInstanciar)
        {
            case 0:
                menorValorDoRandomParaInstanciar = 1.5f;
                maiorValorDoRandomParaInstanciar = 3.0f;
                break;
            case 1:
                menorValorDoRandomParaInstanciar = 1.0f;
                maiorValorDoRandomParaInstanciar = 2.0f;
                break;
            case 2:

                menorValorDoRandomParaInstanciar = 0.5f;
                maiorValorDoRandomParaInstanciar = 1.0f;
                break;
            case 3:

                menorValorDoRandomParaInstanciar = 0.2f;
                maiorValorDoRandomParaInstanciar = 0.5f;
                break;
            case 4:

                menorValorDoRandomParaInstanciar = 0.2f;
                maiorValorDoRandomParaInstanciar = 0.5f;
                break;

        }


        float divisaodovalorfinal = velocidadeFinal / 2;

    }
    IEnumerator aguardaParaInstanciar()
    {

        yield return new WaitForSeconds(Random.Range(menorValorDoRandomParaInstanciar, maiorValorDoRandomParaInstanciar));
        if (QuantidadeDeCarrosNaDireita < 7 && QuantidadeDeCarrosNaDireita >= 0)
        {
            if (podeInstanciarCarroFrente == true)
            {

                float sorteiaFaixa = Random.Range(1, 10);

                if (sorteiaFaixa > 0 && sorteiaFaixa < 6)
                    Instantiate(CarroEsquerda, new Vector3(-6f, 12.0f, 10.4f), new Quaternion(0.0f, 180.0f, 0.0f, 0.0f));

                else
                    Instantiate(CarroEsquerda, new Vector3(-19f, 12.0f, 10.4f), new Quaternion(0.0f, 180.0f, 0.0f, 0.0f));
                QuantidadeDeCarrosNaDireita++;

            }
            if (podeInstanciarCarroTras == true)
            {
                float sorteiaFaixa = Random.Range(1, 10);

                if (sorteiaFaixa > 0 && sorteiaFaixa < 6)
                    Instantiate(CarroEsquerda, new Vector3(-6f, 12.0f, 630.4f), new Quaternion(0.0f, 180.0f, 0.0f, 0.0f));

                else
                    Instantiate(CarroEsquerda, new Vector3(-19f, 12.0f, 630.4f), new Quaternion(0.0f, 180.0f, 0.0f, 0.0f));
                QuantidadeDeCarrosNaDireita++;
            }
        }

        StartCoroutine(aguardaParaInstanciar());
    }

    public void ContadordeVelocidadeParaControlarInstanciação()
    {
        if (speed < 10)
        {
            verificaAVelocidadeParaInstanciar = 0;
        }
        else if (speed <= 200 && speed > 50)
        {
            verificaAVelocidadeParaInstanciar = 1;
        }
        else if (speed <= 300 && speed > 200)
        {
            verificaAVelocidadeParaInstanciar = 2;
        }
        else if (speed <= 400 && speed > 300)
        {
            verificaAVelocidadeParaInstanciar = 3;
        }
        else if (speed <= 500 && speed > 400)
        {
            verificaAVelocidadeParaInstanciar = 4;
        }
        else if (speed < 500)
        {
            verificaAVelocidadeParaInstanciar = 4;
        }
    }


}
