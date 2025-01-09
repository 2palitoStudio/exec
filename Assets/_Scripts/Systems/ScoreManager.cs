using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        instance = this;
    }

    public void AddScore(int points)
    {
        score += points;
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
        public void ResetScore()
    {
        score = 0;
        if (scoreText != null)
        {
            scoreText.text = "0";
        }
    }

}
