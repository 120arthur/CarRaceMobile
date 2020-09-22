using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chegada : MonoBehaviour
{

    public GameObject marcaLocal;
    float speed;

    void Update()
    {
        speed = solo.speed;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.z > 735.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("cenario"))
        {
            Destroy(other.gameObject); 
        }
        if (other.gameObject.CompareTag("carro"))
        {
            marcaLocal.gameObject.SetActive(false);
        }
    }

}
