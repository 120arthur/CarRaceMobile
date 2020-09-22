using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrosIndo : MonoBehaviour
{

    public float velocidade;
    public float valorMaximoDeVelocidade = 0;
    public float valorMinimoDeVelocidade = 0;
    public float sorteiaAVelocidade;
    RaycastHit pontodecolisão;
    public bool parar;

    private void Start()
    {
        valorMaximoDeVelocidade = -90;
        valorMinimoDeVelocidade = -40;
        sorteiaAVelocidade = -(Random.Range(valorMinimoDeVelocidade, valorMaximoDeVelocidade));
        StartCoroutine(DetectaObstaculo());
    }

    void Update()
    {
        // permite que os caroos andem 
        if (parar == false)
        {
            velocidade = -solo.speed + sorteiaAVelocidade;
        }
        if (parar == true)
        {
            velocidade = -solo.speed;
        }

        transform.Translate(Vector3.forward * velocidade * Time.deltaTime);


        if (transform.position.z > 660.0f || transform.position.z < 8.0f)
        {
            if (instanciadorCarroDireita.QuantidadeDeCarrosNaDireita >= 1) instanciadorCarroDireita.QuantidadeDeCarrosNaDireita--;
            Destroy(gameObject);
        }
    }
    IEnumerator DetectaObstaculo()
    {
        if (Physics.Raycast(transform.position, transform.forward, out pontodecolisão, 40) == true && velocidade > 0 && pontodecolisão.transform.gameObject.tag != ("chegada"))
        {
            Debug.DrawLine(transform.position, pontodecolisão.point);

            if (Physics.Raycast(transform.position, transform.forward, 25) == true)
            {
                parar = true;
        
                if (velocidade < 0)
                {
                    velocidade = 0.0f;
                    sorteiaAVelocidade = -(Random.Range(valorMinimoDeVelocidade, valorMaximoDeVelocidade));
                }
                else
                {
                    if (pontodecolisão.transform.gameObject.tag == ("carro"))
                    {
                        velocidade = valorMinimoDeVelocidade;
                    }
                    else
                    {
                        velocidade -= 10.0f;
                    }
                }
            }
            else if (pontodecolisão.transform.gameObject.tag != ("carro") && pontodecolisão.transform.gameObject.tag != ("instanciador") )
            {
                parar = false;
                if (velocidade > 0)
                {
                    velocidade += 2.0f;

                }
                else if (velocidade > 40)
                {
                    velocidade += 4.0f;
                }
                else if (velocidade > 60)
                {
                    velocidade += 5.0f;
                }
                else if (velocidade > 70)
                {
                    velocidade += 9.0f;
                }
                else if (velocidade > 100)
                {
                    velocidade += 12.0f;
                }
            }
        }

        else if (Physics.Raycast(transform.position, transform.forward, 40) == false && velocidade < sorteiaAVelocidade)
        {
            parar = false;
            velocidade -= 2.0f;
        }
        yield return new WaitForSeconds(0.001f);
        StartCoroutine(DetectaObstaculo());
    }
}
