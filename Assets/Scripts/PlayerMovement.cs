using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;


    float movementY;
    float movementX;
    public float movementSpeed;
    public float maximumSpeed;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > maximumSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maximumSpeed);
        }
        FaceTheCursor();

        movementY = Input.GetAxis("Vertical");
        movementX = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * movementY * movementSpeed);
        rb.AddRelativeForce(Vector3.right * movementX * movementSpeed);
    }

    void FaceTheCursor()
    {
        //Uses camera to determine mouse position on a plane
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //plane for ray to hit
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float distance;
        if (ground.Raycast(ray, out distance))
        {
            Vector3 target = ray.GetPoint(distance);
            Vector3 direction = target - transform.position;
            float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }

    }
    
}
