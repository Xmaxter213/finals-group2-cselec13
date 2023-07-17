using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSpike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject whatHit = collision.gameObject;
        if (whatHit.CompareTag("Player"))
        {
            Debug.Log("Player still taking damage");
        }
    }
}
