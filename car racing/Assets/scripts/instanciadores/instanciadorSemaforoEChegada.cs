using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciadorSemaforoEChegada : MonoBehaviour
{
    public GameObject semaforo;
    public GameObject chegada;
    float contadorDeKm;
    float speed;
    float velocidadeFinal;
    float limiteDeKmParaInstanciarFarol = 42.0f;
    bool podeInstanciarSemaforo = true;
    public bool podeInstanciarchegada = true;
    public float ultimoKmParaInstanciarFarol;

    void Start()
    {
        StartCoroutine(aguardaParaInstanciar());
        ultimoKmParaInstanciarFarol = limiteDeKmParaInstanciarFarol * 4;
    }

    void Update()
    {
        contadorDeKm = solo.kmPercorrido;
        speed = solo.speed;
        velocidadeFinal = solo.velocidadeFinal;

        float divisaodovalorfinal = velocidadeFinal / 2;
    }

    IEnumerator aguardaParaInstanciar()
    {

        //  validador de quando podemos instanciar o farol
        if (contadorDeKm < limiteDeKmParaInstanciarFarol && limiteDeKmParaInstanciarFarol < ultimoKmParaInstanciarFarol )
        {
            podeInstanciarSemaforo = true;
        }
        //Instancia semaforo
        if (contadorDeKm > limiteDeKmParaInstanciarFarol && podeInstanciarSemaforo == true)
        {
            Instantiate(semaforo, new Vector3(-13.0f, 12.5f, -17.0f), transform.rotation);
            podeInstanciarSemaforo = false;
            limiteDeKmParaInstanciarFarol += 30.0f;
            
        }
        // instancia Chegada
        if ( contadorDeKm > ultimoKmParaInstanciarFarol && podeInstanciarchegada)
        {
            Instantiate(chegada, new Vector3(27.0f, 21.0f, 0.0f), transform.rotation);
            podeInstanciarchegada = false;
        }

        yield return new WaitForSeconds(0.01f);

        StartCoroutine(aguardaParaInstanciar());
    }
}
