using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed;
    public float turnSpeed;
    Rigidbody rb;

    public Transform player;

    bool alive = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        if (alive)
        {
            Vector3 lookPosition = player.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(lookPosition, Vector3.up);
            float eulerY = lookRotation.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, eulerY, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

        }

    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * movementSpeed);
    }

}
