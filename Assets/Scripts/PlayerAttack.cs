using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public GameObject attack1;
    public GameObject attack2;
    public GameObject attack3;

    public float attackCooldown;
    private float cooldownTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }


        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            cooldownTimer = attackCooldown;
            Instantiate(attack1, transform.position, Quaternion.identity);
        }
        
    }
}
