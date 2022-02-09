using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool playerIsAlive = true;

    GameObject pauseMenu;
    GameObject highScoreCounter;

    [Header("Cursor Settings")]
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            pauseMenu = FindObjectOfType<PauseMenu>().transform.GetChild(0).gameObject; //Get first child of the pause menu, which is the bit with all the graphics etc.
        }
    }

    private void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
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
