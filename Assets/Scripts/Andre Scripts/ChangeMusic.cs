using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    [SerializeField] AudioSource levelAudio;
    [SerializeField] AudioSource bossAudio;
    Collider2D soundTrigger;

    private void Awake()
    {
        //levelAudio = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider2D>();
        levelAudio.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(StartBossMusic());
        }
    }

    IEnumerator StartBossMusic()
    {
        //Makes sure it only triggers once
        soundTrigger.enabled = false;
        yield return new WaitForSeconds(1.2f);
        levelAudio.Stop();
        bossAudio.Play();

        //soundTrigger.enabled = true;
    }
}
