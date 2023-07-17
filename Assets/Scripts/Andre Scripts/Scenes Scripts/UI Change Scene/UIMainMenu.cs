using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] Button _newGame;

    void Start()
    {
        //_newGame.onClick.AddListener(StartNewGame);
    }

    private void StartNewGame()
    {
        //To load a specific scene
        //ScenesManager.Instance.LoadScene(ScenesManager.Scene.MainMenu)
        
        //Resets game progress to nothing
        //PlayerPrefs.SetInt("levelsUnlocked", 0);
        //ScenesManager.Instance.LoadNewGame();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("GAME QUIT");
    }
}
