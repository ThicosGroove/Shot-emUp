using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GamePointSystem : MonoBehaviour
{
    //perguntar pra paolla poq pode usar static sem problema aqui
    public static GamePointSystem instance;

    [SerializeField] private int scorePerKill = 100;

    public int score = 0;
    private int maxScore;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text maxScoreText;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        PlayerPrefs.GetInt("highscore", 0);

        scoreText.text = "Score: " + 0;
    }

    void Update()
    {
        UpdateMaxScore();
    }

    //se mata o inimigo soma, se morre multiplica por 0;
    public void UpdateScore(int killScore)
    {
        if (killScore > 0)
        {
            killScore = scorePerKill;
            score += killScore;
        }
        else
        {
            score *= 0;
        }

        scoreText.text = "Score " + score;
    }

    private void UpdateMaxScore()
    {
        if (score > maxScore)
        {
            maxScore = score;
            PlayerPrefs.SetInt("highscore", maxScore);
        }
        maxScoreText.text = "MaxScore: " + maxScore;
    }
}
