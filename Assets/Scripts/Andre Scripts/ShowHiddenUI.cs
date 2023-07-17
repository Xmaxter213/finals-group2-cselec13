using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHiddenUI : MonoBehaviour
{
    [SerializeField] GameObject sceneTransition;
    [SerializeField] GameObject UI;

    //Destroy, kasi nagloloko siya
    [SerializeField] GameObject destroyLoadingBox;
    [SerializeField] GameObject destroyLoadingText;
    void Start()
    {
        sceneTransition.SetActive(true);
        UI.SetActive(true);
        StartCoroutine(hideLoadingBox());
    }

    IEnumerator hideLoadingBox()
    {
        yield return new WaitForSeconds(2f);
        //loadingBox.alpha = 0;
        //loadingBox.SetActive(false);
        Destroy(destroyLoadingBox);
        Destroy(destroyLoadingText);
    }

}
