using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript Instance { get; private set; }

    [SerializeField] GameObject persistentScore1;
    public float score = 120;

    private void Awake()
    {
        //saying gameObject means this.gameObject
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(persistentScore1);
    }

    private void Update()
    {
        //score = score + Time.deltaTime;
        //Debug.Log(score);
    }
}
