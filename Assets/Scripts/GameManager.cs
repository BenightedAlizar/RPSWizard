using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool playerIsAlive = true;

    GameObject pauseMenu;
    GameObject highScoreCounter;


    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            pauseMenu = FindObjectOfType<PauseMenu>().transform.GetChild(0).gameObject; //Get first child of the pause menu, which is the bit with all the graphics etc.
        }
    }


    private void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            if (pauseMenu != null)
            {
                if (pauseMenu.gameObject.activeInHierarchy)
                {
                    pauseMenu.gameObject.SetActive(false);
                    Time.timeScale = 1;

                }
                else
                {
                    pauseMenu.gameObject.SetActive(true);
                    Time.timeScale = 0;
                }
            }

        }
    }

}
