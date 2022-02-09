using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreCounter : MonoBehaviour
{


    public int highscore;
    public TextMeshProUGUI highScoreText;

    ScoreCounter scoreCounter;



    private void Awake()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>();
        highScoreText = GetComponent<TextMeshProUGUI>();
        highscore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Start()
    {
        highScoreText.text = "High Score: " + highscore;
    }

    public void AddScore(int addedScore)
    {
        highscore += addedScore;
        highScoreText.text = "High Score: " + highscore;

    }

    public void UpdateHighScoreDisplay() //Updates just the text, doesn't write data into playerprefs. Don't write data to HDD/SSD unless you need to.
    {
        if (scoreCounter.score >= highscore) //maybe setting ">" instead of ">=" would also work, playing it safe
        {
            highscore = scoreCounter.score;
            highScoreText.text = "High Score: " + highscore;
        }
    }



    public void UpdateHighScoreAndSave()
    {
        if (scoreCounter.score >= highscore)
        {
            highscore = scoreCounter.score;
            PlayerPrefs.SetInt("HighScore", highscore);
            highScoreText.text = "High Score: " + highscore;
        }
    }

}
