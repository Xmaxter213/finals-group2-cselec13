using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GetScore : MonoBehaviour
{
    //For scoreboard
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private TMP_Text currentScore;
    [SerializeField] private int currentLevel;

    private float score;
    //[SerializeField] private TMP_Text showPrevScore;


    void Start()
    {
        
    }

    public void ShowCurrentScore()
    {
        scoreText.text = "Score: " + currentScore.text;
    }

    public string GetPreviousLevelScore(int previousLevel)
    {
        if (previousLevel.Equals(1))
        {
            score = PlayerPrefs.GetFloat("scoreTutorial");
            return score.ToString();
        }
        else if (previousLevel.Equals(2))
        {
            score = PlayerPrefs.GetFloat("score1");
            return score.ToString();
        }
        else if (previousLevel.Equals(3))
        {
            score = PlayerPrefs.GetFloat("score2");
            return score.ToString();
        }
        else if (previousLevel.Equals(4))
        {
            score = PlayerPrefs.GetFloat("score3");
            return score.ToString();
        }
        return null;
    }

    public void ShowHighScore()
    {
        if (currentLevel.Equals(1))
        {
            score = PlayerPrefs.GetFloat("scoreTutorial");
            //showPrevScore.text = score.ToString();
        }
        else if (currentLevel.Equals(2))
        {
            score = PlayerPrefs.GetFloat("score1");
        }
        else if (currentLevel.Equals(3))
        {
            score = PlayerPrefs.GetFloat("score2");
        }
        else if (currentLevel.Equals(4))
        {
            score = PlayerPrefs.GetFloat("score3");
        }
    }
}
