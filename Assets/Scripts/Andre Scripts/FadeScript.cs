using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    [SerializeField] private CanvasGroup myUIGroup;

    [SerializeField] private bool fadeIn = false;
    [SerializeField] private bool fadeOut = false;

    private BoxCollider2D boxTrigger;

    public void ShowUI()
    {
        fadeIn = true;
    }

    public void HideUI()
    {
        fadeOut = true;
    }

    void Start()
    {
        boxTrigger = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            if (myUIGroup.alpha < 1)
            {
                myUIGroup.alpha += Time.deltaTime * 2;
                if (myUIGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut)
        {
            if (myUIGroup.alpha >= 0)
            {
                myUIGroup.alpha -= Time.deltaTime * 2;
                if (myUIGroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            
            boxTrigger.enabled = false;
            ShowUI();
            Invoke("HideUI", 5f);
            //Invoke("EnableBoxCollider", 8f);
        }
    }


    public void EnableBoxCollider()
    {
        boxTrigger.enabled = true;
    }
}
