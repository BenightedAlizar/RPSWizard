using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{

    public float speed;
    Rigidbody rb;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * speed);
    }
}
