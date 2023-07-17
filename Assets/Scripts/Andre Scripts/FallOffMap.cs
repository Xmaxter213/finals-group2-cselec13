using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOffMap : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = teleportTarget.transform.position;
        }
    }
}
