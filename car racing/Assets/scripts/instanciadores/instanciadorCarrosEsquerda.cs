using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciadorCarrosEsquerda : MonoBehaviour

{
    float speed;
    public GameObject CarroEsquerda;

    private float velocidadeFinal;
    private float menorValorDoRandomParaInstanciar;
    private float maiorValorDoRandomParaInstanciar;
    private byte verificaAVelocidadeParaInstanciar;
    [SerializeField]
    private bool podeInstanciarCarro = true;
    [SerializeField]
    public static int QuantidadeDeCarrosNaEsquerda = 0;



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
        if (QuantidadeDeCarrosNaEsquerda < 5  && QuantidadeDeCarrosNaEsquerda >= 0)
        {
            float sorteiaFaixa = Random.Range(1, 10);
            if (sorteiaFaixa > 0 && sorteiaFaixa < 6)
                Instantiate(CarroEsquerda, new Vector3(6f, 12.0f, -126.0f), transform.rotation);

            else
                Instantiate(CarroEsquerda, new Vector3(18f, 12.0f, -126.0f), transform.rotation);

            QuantidadeDeCarrosNaEsquerda++;
        }

        StartCoroutine(aguardaParaInstanciar());
    }

    public void ContadordeVelocidadeParaControlarInstanciação()
    {
        if (speed < 50)
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
    }

}
