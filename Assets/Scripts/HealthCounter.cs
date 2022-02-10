using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCounter : MonoBehaviour
{



    public List<GameObject> hearts;

    public int health;


    PlayerHealth playerHealth;


    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }


    private void Start()
    {
        health = playerHealth.health;
    }

    public void UpdateHealth()
    {
        health = playerHealth.health;

        foreach (GameObject item in hearts)
        {
            item.gameObject.SetActive(false);
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].SetActive(true);
        }

    }


}
