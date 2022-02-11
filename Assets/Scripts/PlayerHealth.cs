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

    SkinnedMeshRenderer meshRenderer;
    HealthCounter healthCounter;
    Spawners spawnerScript;
    GameManager gameManager;
    HighScoreCounter highScoreCounter;

    public GameObject veleho;

    AudioSource audioSource;
    public AudioClip deathSound;


    private void Awake()
    {
        attackScript = GetComponent<PlayerAttack>();
        movementScript = GetComponent<PlayerMovement>();
        meshRenderer = veleho.GetComponent<SkinnedMeshRenderer>();
        healthCounter = FindObjectOfType<HealthCounter>();
        spawnerScript = FindObjectOfType<Spawners>();
        gameManager = FindObjectOfType<GameManager>();
        highScoreCounter = FindObjectOfType<HighScoreCounter>();
        audioSource = GetComponent<AudioSource>();
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


    private void Update()
    {
        if (transform.position.y < -5)
        {
            Die();
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
            Die();
        }

        healthCounter.UpdateHealth();
    }

    void Die()
    {
        audioSource.PlayOneShot(deathSound);
        alive = false;
        health = 0;
        deathPopup.SetActive(true);
        meshRenderer.enabled = false;
        gameManager.playerIsAlive = false;

        highScoreCounter.UpdateHighScoreAndSave();
    }

}
