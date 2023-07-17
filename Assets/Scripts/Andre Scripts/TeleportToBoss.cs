using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToBoss : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject player;
    public Animator transition;
    public Canvas crossfade;

    private void Start()
    {
        StartCoroutine(EnableCrossfade());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            transition.SetTrigger("BossTransition");
            StartCoroutine(TeleportPlayer());
        }
    }

    IEnumerator EnableCrossfade()
    {
        yield return new WaitForSeconds(1f);
        crossfade.enabled = true;
    }
    IEnumerator TeleportPlayer()
    {
        //play animation
        yield return new WaitForSeconds(2.2f);
        player.transform.position = teleportTarget.transform.position;
    }
}
