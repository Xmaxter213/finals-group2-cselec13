using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;
    private IncrementSetScore setScore;

    //For scene transition
    public Animator transition;
    public float transitionTime = 0f;
    private void Awake()
    {
        //this makes it so that we can access this class from anywhere using ScenesManager.instance
        Instance = this;
    }

    public enum Scene
    {
        MainMenu,
        Tutorial,
        Level01,
        Level02,
        Level03
    }

    public void LoadScene(Scene scene)
    {
        //This is from the import, not the script we made
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadScene(int index)
    {
        //This is from the import, not the script we made
        //SceneManager.LoadScene(index);
        StartCoroutine(LoadLevel(index));
    }

    public void LoadNewGame()
    {

        //SceneManager.LoadScene(Scene.Tutorial.ToString());
        StartCoroutine(LoadLevel(1));
        PlayerPrefs.SetInt("levelsUnlocked", 0);
    }

    public void LoadNextScene()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void StartTransition()
    {
        //play animation
        transition.SetTrigger("Start");
    }
}
