using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShowScoreFromPreviousLevel : MonoBehaviour
{
    private GetScore getScore;
    private int previousLevel;
    private string previousLevelScore;

    [SerializeField] private TMP_Text scoreInStartTransition;

    void Start()
    {
        
        getScore = GetComponent<GetScore>();
        getActiveScene();
        previousLevelScore = getScore.GetPreviousLevelScore(previousLevel);
        scoreInStartTransition.text = "Score: " + previousLevelScore;
        //scoreInStartTransition = ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getActiveScene()
    {
        previousLevel = SceneManager.GetActiveScene().buildIndex - 1;
    }
}
