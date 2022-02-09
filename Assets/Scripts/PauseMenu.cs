using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    GameObject pauseMenuGraphics;

    HighScoreCounter highScoreCounter;


    private void Awake()
    {
        pauseMenuGraphics = transform.GetChild(0).gameObject;
        highScoreCounter = FindObjectOfType<HighScoreCounter>();
    }


    public void ResumeGame()
    {
        pauseMenuGraphics.SetActive(false);
        Time.timeScale = 1;
    }


    public void ReturnToMenu()
    {
        highScoreCounter.UpdateHighScoreAndSave();

        Time.timeScale = 1;
        SceneManager.LoadScene("StartMenu");
    }

     
    public void QuitGame()
    {
        highScoreCounter.UpdateHighScoreAndSave();
        Invoke("ActuallyQuit", 0.01f);
    }

    private void ActuallyQuit()
    {
        Application.Quit();
    }
}
