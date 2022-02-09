using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    HighScoreCounter highScoreCounter;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        highScoreCounter = FindObjectOfType<HighScoreCounter>();
    }

    private void Start()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int addedScore)
    {
        score += addedScore;
        scoreText.text = "Score: "+ score;

        if (score > highScoreCounter.highscore)
        {
            highScoreCounter.highscore = score;
        }
    }
}
