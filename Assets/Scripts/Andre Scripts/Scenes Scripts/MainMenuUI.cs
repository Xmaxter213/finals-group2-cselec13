using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelSelect;

    private void Start()
    {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
    }
    public void levelSelectClicked()
    {
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void levelSelectBackClicked()
    {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
    }

    /**public void resetPlayerProgress()
    {
        PlayerPrefs.SetInt("levelsUnlocked", 0);
        Debug.Log("Progress has been reset!");
    }**/
}
