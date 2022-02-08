using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public GameObject rockAttack;
    public GameObject paperAttack;
    public GameObject scissorsAttack;

    public float attackCooldown;
    private float cooldownTimer;


    public enum ChosenSpell
    {
        Rock, Paper, Scissors
    }


    public ChosenSpell chosenSpell;

    // Start is called before the first frame update
    void Start()
    {
        chosenSpell = ChosenSpell.Rock;
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

            switch (chosenSpell)
            {
                case ChosenSpell.Rock:
                    Instantiate(rockAttack, transform.position + transform.forward * 2, transform.rotation);
                    break;
                case ChosenSpell.Paper:
                    Instantiate(paperAttack, transform.position + transform.forward * 2, transform.rotation);
                    break;
                case ChosenSpell.Scissors:
                    Instantiate(scissorsAttack, transform.position + transform.forward * 2, transform.rotation);
                    break;
                default:
                    break;
            }
        }



        if (Input.GetButtonDown("Rock"))
        {
            chosenSpell = ChosenSpell.Rock;
        }
        else if (Input.GetButtonDown("Paper"))
        {
            chosenSpell = ChosenSpell.Paper;
        }
        else if (Input.GetButtonDown("Scissors"))
        {
            chosenSpell = ChosenSpell.Scissors;
        }

    }


}
