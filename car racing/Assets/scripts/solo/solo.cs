using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class solo : MonoBehaviour
{

    public static float velocidadeFinal = 200.0f;
    public static float speed = 0;
    public static bool parando = false;
    public bool AcabouOJogo = false;
    public GameObject chao1;
    public GameObject chao2;
    public static float kmPercorrido = 0;
    [SerializeField]
    float kmQueAumentaAVelocidadeFinal = 50.2f;
    [SerializeField]
    byte vezesQueAVelocidadeAumentou = 0;

    public GameObject Instanciador;

    void Start()
    {
        StartCoroutine(aumentarEDiminirVelocidade());
    }

    void FixedUpdate()
    {
        chao1.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        chao2.transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (chao1.transform.position.z > 874.0f)
        {
            chao1.transform.position = new Vector3(chao1.transform.position.x, chao1.transform.position.y, -563.0f);
        }

        if (chao2.transform.position.z > 874.0f)
        {
            chao2.transform.position = new Vector3(chao2.transform.position.x, chao2.transform.position.y, -563.0f);
        }

        // conta os km
        if (kmPercorrido >= kmQueAumentaAVelocidadeFinal && vezesQueAVelocidadeAumentou <= 3 && kmQueAumentaAVelocidadeFinal <= 330)
        {
            velocidadeFinal += 100;
            vezesQueAVelocidadeAumentou++;
            kmQueAumentaAVelocidadeFinal += 35.0f;
        }
    }
    // aumenta e diminui a velocidade do carro
    public IEnumerator aumentarEDiminirVelocidade()
    {
        if (AcabouOJogo == true)
        {
            speed = speed - 8.0f;

            if (speed <= 0)
            {
                speed = 0;
            }
        }
        else if (AcabouOJogo == false)
        {

            if (velocidadeFinal >= speed && parando == false)
            {
                speed = speed + 1.5f;

                // verifica a velocidade 
                ContadordekmPercorridoEnquantoAcelera();

                parando = false;
            }
            else if (parando == true && speed > 0)
            {
                // verifica a velocidade 
                ContadordekmPercorridoEnquantoPara();
                speed = speed - 22.0f;

                if (speed <= 0)
                {
                    parando = true;
                    speed = 0;
                }
            }
            else if (velocidadeFinal <= speed && parando == false)
            {
                // verifica a velocidade 
                ContadordekmPercorridoEnquantoAcelera();
                parando = false;
            }
        }
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(aumentarEDiminirVelocidade());
    }
    public void ContadordekmPercorridoEnquantoAcelera()
    {
        if (speed <= 200)
        {
            kmPercorrido = kmPercorrido + 0.1f;
        }
        else if (speed <= 300 && speed > 200)
        {
            kmPercorrido = kmPercorrido + 0.2f;
        }
        else if (speed <= 400 && speed > 300)
        {
            kmPercorrido = kmPercorrido + 0.3f;
        }
        else if (speed <= 500 && speed > 400)
        {
            kmPercorrido = kmPercorrido + 0.4f;
        }
    }
    public void ContadordekmPercorridoEnquantoPara()
    {
        if (speed <= 200)
        {
            kmPercorrido = kmPercorrido + 0.01f;
        }
        else if (speed <= 300 && speed > 200)
        {
            kmPercorrido = kmPercorrido + 0.02f;
        }
        else if (speed <= 400 && speed > 300)
        {
            kmPercorrido = kmPercorrido + 0.03f;
        }
        else if (speed <= 500 && speed > 400)
        {
            kmPercorrido = kmPercorrido + 0.04f;
        }
    }
}
