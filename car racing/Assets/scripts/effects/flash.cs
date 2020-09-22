using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.6f);   
    }
}
