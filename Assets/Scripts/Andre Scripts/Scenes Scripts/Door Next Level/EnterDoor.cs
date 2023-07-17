using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterDoor : MonoBehaviour
{
    private bool enterAllowed;
    //private string sceneToLoad;
    public HasKey hasKeyScript;
    public GameObject door;
    public Sprite openedDoorSprite;
    private bool isDoorOpen = false;
    //[SerializeField] private GameObject scoreboard;
    //[SerializeField] private TMP_Text currentscore, scoreboardText;

    IncrementSetScore stopScore;
    [SerializeField] private GameObject score;
    [SerializeField] ScenesManager scenesManager;
    [SerializeField] GetScore getScore;
    [SerializeField] IncrementSetScore stopScoreIncrement;

    [SerializeField] private GameObject EnterDoorUI;

    private void Awake()
    {
        stopScore = score.GetComponent<IncrementSetScore>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<NextLevelDoor>())
        {
            if (isDoorOpen == true)
            {
                EnterDoorUI.SetActive(true);
            }

            enterAllowed = true;
            Debug.Log("Player is touching the door");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enterAllowed = false;
        EnterDoorUI.SetActive(false);
        Debug.Log("Player is not touching the door");
    }

    private void Update()
    {
        // && hasKeyScript.hasKey
        if (enterAllowed == true && isDoorOpen == true && Input.GetKey(KeyCode.E))
        {
            //door.GetComponent<SpriteRenderer>().sprite = openedDoorSprite;
            //isDoorOpen = true;
            //Debug.Log("Door is now open");
            //scoreboardText.text = currentscore.text;
            
            scenesManager.StartTransition();
            stopScoreIncrement.CurrentLevelFinished();
            getScore.ShowCurrentScore();
            //scoreboard.SetActive(true);
            //stopScore.CurrentLevelFinished();
        }

        /**if (isDoorOpen && Input.GetKey(KeyCode.E))
        {
            Invoke("EnterOpenedDoor", 3f);
        }shit doesnt work :/ **/ 
    }

    public void EnterOpenedDoor()
    {
        ScenesManager.Instance.LoadNextScene();
        Debug.Log("Successfully entered door");
    }

    public void OpenDoor()
    {
        door.GetComponent<SpriteRenderer>().sprite = openedDoorSprite;
        isDoorOpen = true;
        Debug.Log("Door is now open");
    }
}
