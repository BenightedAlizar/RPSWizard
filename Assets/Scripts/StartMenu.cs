using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject instructionsMenu;

    public AudioSource audioSource;



    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        audioSource.PlayOneShot(audioSource.clip);
        SceneManager.LoadScene("MainScene");
    }




    public void OpenInstructions()
    {
        audioSource.PlayOneShot(audioSource.clip);
        instructionsMenu.SetActive(true);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
