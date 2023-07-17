using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Attack();
        }

        if (Input.GetMouseButton(1))
        {
            Shoot();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }

    void Shoot()
    {
        animator.SetTrigger("Shoot");
    }
}
