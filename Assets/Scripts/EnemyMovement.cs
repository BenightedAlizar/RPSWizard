using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed;
    public float turnSpeed;
    Rigidbody rb;

    public Transform player;

    public bool alive = true;

    public bool falling;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        if (alive && !falling)
        {
            Vector3 lookPosition = player.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(lookPosition, Vector3.up);
            float eulerY = lookRotation.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, eulerY, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);

        }


        Vector3 groundCheck = new Vector3(transform.position.x, transform.position.y -1 , transform.position.z);

        if (!Physics.Linecast(transform.position, groundCheck))
        {
            falling = true;
        }
        else
        {
            falling = false;
        }
    }


    private void FixedUpdate()
    {
        if (alive && !falling)
        {
            rb.AddRelativeForce(Vector3.forward * movementSpeed);
        }
        else if (falling)
        {
            rb.AddRelativeForce(Vector3.down * 100);
        }
    }



}
