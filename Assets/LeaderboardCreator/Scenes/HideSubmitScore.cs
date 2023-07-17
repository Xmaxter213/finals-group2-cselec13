using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSubmitScore : MonoBehaviour
{
    public void hideLeaderboardUI()
    {
        PlayerPrefs.SetInt("showLeaderboardUI", 0);
    }
}
