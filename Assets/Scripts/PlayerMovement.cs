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

    GameManager gameManager;
    private bool falling;
    public float fallSpeed;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Groundcheck();


        if (gameManager.playerIsAlive)
        {
            if (rb.velocity.magnitude > maximumSpeed)
            {
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maximumSpeed);
            }
            FaceTheCursor();

            movementY = Input.GetAxis("Vertical");
            movementX = Input.GetAxis("Horizontal");
        }

    }

    private void FixedUpdate()
    {
        if (gameManager.playerIsAlive)
        {
            rb.AddForce(Vector3.forward * movementY * movementSpeed);
            rb.AddForce(Vector3.right * movementX * movementSpeed);
        }
        if (falling)
        {
            rb.AddRelativeForce(Vector3.down * fallSpeed);
        }
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

    void Groundcheck()
    {
        Vector3 groundCheck = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);

        if (!Physics.Linecast(transform.position, groundCheck))
        {
            falling = true;
        }
        else
        {
            falling = false;
        }
    }



    
}
