using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] MovingCube textScore;

    private int highScore = 0;
    private int score = 0;


    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        highScoreText.text = "HighScores: " + highScore.ToString();
    }
    private void Update()
    {
        scoreText.text = textScore.level.ToString() + " POINTS";
        score = textScore.level;

        if (highScore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

}
