using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target;
    [SerializeField]
    float smothSpeed = 0.100f;
    public Vector3 offset;
    bool oi = true;
    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 580.1f);

    }
    void FixedUpdate()
    {
      
            if (transform.position.z >= 614.0f)
            {
                smothSpeed = 0.125f;
            }
            Vector3 desiredPosition = target.position + offset;
            Vector3 smothPosition = Vector3.Lerp(transform.position , desiredPosition, smothSpeed);
            transform.position = smothPosition;
    
    }
    public void empurraCamera()
    {
        transform.position = new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y + Random.Range(-10, 10), transform.position.z + Random.Range(-10, 10));
    }
}
