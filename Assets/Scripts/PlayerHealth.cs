using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health;

    public bool alive = true;

    PlayerAttack attackScript;
    PlayerMovement movementScript;
    public GameObject deathPopup;

    MeshRenderer meshRenderer;
    HealthCounter healthCounter;
    Spawners spawnerScript;
    GameManager gameManager;


    private void Awake()
    {
        attackScript = GetComponent<PlayerAttack>();
        movementScript = GetComponent<PlayerMovement>();
        meshRenderer = GetComponent<MeshRenderer>();
        healthCounter = FindObjectOfType<HealthCounter>();
        spawnerScript = FindObjectOfType<Spawners>();
        gameManager = FindObjectOfType<GameManager>();
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (alive)
        {
            switch (collision.gameObject.tag)
            {
                case "RockEnemy":
                    Destroy(collision.gameObject);
                    TakeDamage();
                    break;
                case "PaperEnemy":
                    Destroy(collision.gameObject);
                    TakeDamage();
                    break;
                case "ScissorsEnemy":
                    Destroy(collision.gameObject);
                    TakeDamage();
                    break;

                default:
                    break;
            }
        }

    }


    void TakeDamage()
    {

        if (health > 1)
        {
            health--;
        }
        else if (alive)
        {
            health = 0;
            alive = false;
            deathPopup.SetActive(true);
            meshRenderer.enabled = false;
            gameManager.playerIsAlive = false;
        }

        healthCounter.UpdateHealth(health);
        
    }


}
