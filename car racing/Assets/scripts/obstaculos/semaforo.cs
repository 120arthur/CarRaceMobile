using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class semaforo : MonoBehaviour
{
    float speed;
    public bool sinalverde;
    public GameObject corSemaforo1;
    public GameObject corSemaforo2;
    public GameObject corSemaforo3;

    // collider do semaforo
    public Collider coliderSemaforo;

    void Start()
    {
        StartCoroutine(deixarSinalVerde());
    }

    void Update()
    {
        speed = solo.speed;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.z > 735.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("jogador"))
        {
            // adiciona velcidade ao carro
            solo.velocidadeFinal += 100.0f;
        }
    }
    IEnumerator deixarSinalVerde()
    {
        coliderSemaforo.enabled = true;
        sinalverde = false;
        Renderer CorSemaforo1 = corSemaforo1.GetComponent<Renderer>();
        Renderer CorSemaforo2 = corSemaforo2.GetComponent<Renderer>();
        Renderer CorSemaforo3 = corSemaforo3.GetComponent<Renderer>();

        CorSemaforo1.material.SetColor("_Color", Color.red);
        CorSemaforo2.material.SetColor("_Color", Color.red);
        CorSemaforo3.material.SetColor("_Color", Color.red);

        yield return new WaitForSeconds(3.5f);

        CorSemaforo1.material.SetColor("_Color", Color.yellow);
        CorSemaforo2.material.SetColor("_Color", Color.yellow);
        CorSemaforo3.material.SetColor("_Color", Color.yellow);

        yield return new WaitForSeconds(1.0f);
        coliderSemaforo.enabled = false;
        sinalverde = true;
        CorSemaforo1.material.SetColor("_Color", Color.green);
        CorSemaforo2.material.SetColor("_Color", Color.green);
        CorSemaforo3.material.SetColor("_Color", Color.green);

        yield return new WaitForSeconds(6.0f);
        StartCoroutine(deixarSinalVerde());
    }
}
