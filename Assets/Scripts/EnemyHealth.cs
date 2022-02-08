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


    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
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
                break;
            case "PaperAttack":
                Destroy(collision.gameObject);
                if (weakness == Weakness.Paper)
                {
                    Invoke("DestroyThis", 0.05f);
                }
                break;
            case "ScissorsAttack":
                Destroy(collision.gameObject);
                if (weakness == Weakness.Scissors)
                {
                    Invoke("DestroyThis", 0.05f);
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
