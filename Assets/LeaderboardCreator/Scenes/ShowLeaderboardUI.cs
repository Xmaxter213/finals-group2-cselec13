using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLeaderboardUI : MonoBehaviour
{
    [SerializeField] GameObject UI;
    [SerializeField] private Button submitButton;
    int showUI;
    void Start()
    {
        showUI = PlayerPrefs.GetInt("showLeaderboardUI");

        if (showUI != 1)
        {
            UI.SetActive(false);
            Debug.Log("int value:" + showUI + " FALSE");
        }
        else
        {
            UI.SetActive(true);
            Debug.Log("int value:" + showUI + " TRUE");
        }
    }

    public void disableButton()
    {
        submitButton.interactable = false;
    }
}
