using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMainMenu : MonoBehaviour
{
    [SerializeField] ScenesManager scenesManager;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("space key was pressed");
            scenesManager.LoadScene(7);

            PlayerPrefs.SetInt("showLeaderboardUI", 1);
        }
    }
}
