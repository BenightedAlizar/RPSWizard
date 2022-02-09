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
    public ScoreCounter scoreCounter;

    public float sameTypeKnockback; //knockback from hitting this with the same element (rock vs rock, etc.)

    Rigidbody rb;

    private bool dead;

    private void Awake()
    {
        rb = FindObjectOfType<Rigidbody>();
        movementScript = FindObjectOfType<EnemyMovement>();
        scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5 && movementScript.alive) //fell off the arena!
        {
            movementScript.alive = false;
            Die();
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
                    Invoke("Die", 0.05f);
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
                    Invoke("Die", 0.05f);
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
                    Invoke("Die", 0.05f);
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

    void Die()
    {
        scoreCounter.AddScore(1);
        Destroy(gameObject);
    }


}
