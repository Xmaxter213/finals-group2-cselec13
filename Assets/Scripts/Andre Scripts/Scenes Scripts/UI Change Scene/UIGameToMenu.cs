using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameToMenu : MonoBehaviour
{
    [SerializeField] Button _backToMainManu;

    void Start()
    {
        _backToMainManu.onClick.AddListener(LoadMainMenu);
    }

    private void LoadMainMenu()
    {
        //To load a specific scene
        //ScenesManager.Instance.LoadScene(ScenesManager.Scene.MainMenu)
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.MainMenu);
    }
}
