using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject instructionsMenu;


    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }


    public void OpenInstructions()
    {
        instructionsMenu.SetActive(true);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
