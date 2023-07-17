using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackChecker : MonoBehaviour
{
    private bool withinAttack;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            withinAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            withinAttack = false;
        }
    }

    public bool checker()
    {
        return withinAttack;
    }
}