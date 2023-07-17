using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class IncrementSetScore : MonoBehaviour
{
    [SerializeField] public int level;
    private float score;
    [SerializeField] private TMP_Text currentScore;
    private float finalScore;
    private bool isLevelFinished = false;
    public float minusTimeOnEnemyKilled;

    private void Start()
    {
        /**
        PlayerPrefs.SetFloat("scoreTutorial", 0);
        PlayerPrefs.SetFloat("score1", 0);
        PlayerPrefs.SetFloat("score2", 0);
        PlayerPrefs.SetFloat("score3", 0);
        Debug.Log("SCORES HAVE BEEN RESET");
        **/
    }
    // Update is called once per frame
    void Update()
    {
        if(isLevelFinished.Equals(false))
        {
            score = score + Time.deltaTime;
            float score1 = Mathf.Round(score * 100f) / 100f;
            currentScore.text = score1.ToString();
        }
    }

    public void reduceScore()
    {
        score = score - minusTimeOnEnemyKilled;
    }

    public void CurrentLevelFinished()
    {
        isLevelFinished = true;
    }
    public void SaveScore()
    {
        if (level.Equals(1))
        {
            //score = LevelScores.score1;
            /**if (score > PlayerPrefs.GetFloat("scoreTutorial"))
            {
                PlayerPrefs.SetFloat("scoreTutorial", Mathf.Round(score * 100f) / 100f);
            }**/
            PlayerPrefs.SetFloat("scoreTutorial", Mathf.Round(score * 100f) / 100f);
            //PlayerPrefs.SetString("scoreTutorial", currentScore.text);
            Debug.Log("Score for tutorial has been saved.");
        }
        else if (level.Equals(2))
        {
            PlayerPrefs.SetFloat("score1", Mathf.Round(score * 100f) / 100f);
            //PlayerPrefs.SetString("score1", currentScore.text);
            Debug.Log("Score for level 1 has been saved.");
        }
        else if (level.Equals(3))
        {
            PlayerPrefs.SetFloat("score2", Mathf.Round(score * 100f) / 100f);
            //PlayerPrefs.SetString("score2", currentScore.text);
        }
        else if (level.Equals(4))
        {
            PlayerPrefs.SetFloat("score3", Mathf.Round(score * 100f) / 100f);
            //PlayerPrefs.SetString("score3", currentScore.text);
        }
    }
}
