using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGetter : MonoBehaviour
{
    //[SerializeField] Text text1;

    void Start()
    {
        GetComponent<Text>().text = "SCORE: " + ScoreScript.Instance.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
