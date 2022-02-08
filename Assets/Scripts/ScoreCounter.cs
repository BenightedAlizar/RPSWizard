using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{

    public int score;

    public TextMeshProUGUI scoreText;



    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }


    public void AddScore(int addedScore)
    {
        score += addedScore;
        scoreText.text = "Score: "+ score;

    }
}
