using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    GameObject pauseMenuGraphics;



    private void Awake()
    {
        pauseMenuGraphics = transform.GetChild(0).gameObject;
    }


    public void ResumeGame()
    {
        pauseMenuGraphics.SetActive(false);
        Time.timeScale = 1;
    }


    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
