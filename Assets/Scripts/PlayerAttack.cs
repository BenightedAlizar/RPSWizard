using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public GameObject rockAttack;
    public GameObject paperAttack;
    public GameObject scissorsAttack;
    GameManager gameManager;

    public float attackCooldown;
    private float cooldownTimer;

    public WeaponSelectionUI weaponSelectionUI;


    public enum ChosenSpell
    {
        Rock, Paper, Scissors
    }


    public ChosenSpell chosenSpell;
    public float attackSpawnDistance; //How far away the attack spell spawns from the player


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        weaponSelectionUI = FindObjectOfType<WeaponSelectionUI>();
    }


    // Start is called before the first frame update
    void Start()
    {
        chosenSpell = ChosenSpell.Rock;
        weaponSelectionUI.selectedWeaponAsINT = 1;
        weaponSelectionUI.UpdateWeaponIcon();

    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }


        if (Input.GetButtonDown("Fire1") && cooldownTimer <= 0 && gameManager.playerIsAlive)
        {
            cooldownTimer = attackCooldown;

            switch (chosenSpell)
            {
                case ChosenSpell.Rock:
                    Instantiate(rockAttack, transform.position + transform.forward * attackSpawnDistance, transform.rotation);
                    break;
                case ChosenSpell.Paper:
                    Instantiate(paperAttack, transform.position + transform.forward * attackSpawnDistance, transform.rotation);
                    break;
                case ChosenSpell.Scissors:
                    Instantiate(scissorsAttack, transform.position + transform.forward * attackSpawnDistance, transform.rotation);
                    break;
                default:
                    break;
            }
        }



        if (Input.GetButtonDown("Rock"))
        {
            chosenSpell = ChosenSpell.Rock;
            weaponSelectionUI.selectedWeaponAsINT = 1;
            weaponSelectionUI.UpdateWeaponIcon();
        }
        else if (Input.GetButtonDown("Paper"))
        {
            chosenSpell = ChosenSpell.Paper;
            weaponSelectionUI.selectedWeaponAsINT = 2;
            weaponSelectionUI.UpdateWeaponIcon();
        }
        else if (Input.GetButtonDown("Scissors"))
        {
            weaponSelectionUI.selectedWeaponAsINT = 3;
            weaponSelectionUI.UpdateWeaponIcon();
            chosenSpell = ChosenSpell.Scissors;
        }

    }


}
