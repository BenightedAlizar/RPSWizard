using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public enum Weakness
    {
        Rock, Paper, Scissors
    }


    public Weakness weakness;

    public EnemyMovement movementScript;

    public float sameTypeKnockback; //knockback from hitting this with the same element (rock vs rock, etc.)

    Rigidbody rb;


    private void Awake()
    {
        rb = FindObjectOfType<Rigidbody>();
        movementScript = FindObjectOfType<EnemyMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5) //fell off the arena!
        {
            movementScript.alive = false;
            Destroy(gameObject);
        }   
    }


    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "RockAttack":
                Destroy(collision.gameObject);
                if (weakness == Weakness.Rock)
                {
                    Invoke("DestroyThis", 0.05f);
                }
                else if (gameObject.tag == "RockEnemy")
                {
                    Vector3 moveDirection = transform.position -collision.transform.position;
                    rb.AddForce(moveDirection.normalized * sameTypeKnockback);

                }
                break;
            case "PaperAttack":
                Destroy(collision.gameObject);
                if (weakness == Weakness.Paper)
                {
                    Invoke("DestroyThis", 0.05f);
                }
                else if (gameObject.tag == "PaperEnemy")
                {
                    Vector3 moveDirection = transform.position - collision.transform.position;
                    rb.AddForce(moveDirection.normalized * sameTypeKnockback);

                }
                break;
            case "ScissorsAttack":
                Destroy(collision.gameObject);
                if (weakness == Weakness.Scissors)
                {
                    Invoke("DestroyThis", 0.05f);
                }
                else if (gameObject.tag == "ScissorsEnemy")
                {
                    Vector3 moveDirection = transform.position - collision.transform.position;
                    rb.AddForce(moveDirection.normalized * sameTypeKnockback);

                }
                break;
            default:
                break;
        }

    }


    void DestroyThis()
    {
        Destroy(gameObject);
    }


}
