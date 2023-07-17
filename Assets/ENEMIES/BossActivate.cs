using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivate : MonoBehaviour
{
    public GameObject boss;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            boss.SetActive(true);
        }
    }
}
