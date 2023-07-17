using System.Collections;
using System.Collections.Generic;
using System.Data;
//using Unity.VisualScripting;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public float attackSpeed;
    public int attackDamage;

    [SerializeField] private float currentAS;


    void Start()
    {
        currentAS = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentAS--;
        if(Input.GetKeyDown(KeyCode.Mouse0) && currentAS <= 0)
        {
            attack();
            currentAS = attackSpeed;
        }
    }

    //this is for all bosses and enemy now, make sure all bosses are in the enemy layer
    void attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("hit");
                bossMechanic boss1 = enemy.GetComponent<bossMechanic>();
                BossMechanic2 boss2 = enemy.GetComponent<BossMechanic2>();
                BossMechanic3 boss3 = enemy.GetComponent<BossMechanic3>();


            if (boss1 != null)
            {
                boss1.GetComponent<bossMechanic>().hit();
            }
            if(boss2 != null)
            {
                boss2.GetComponent<BossMechanic2>().hit();
            }
            if (boss3 != null)
            {
                boss3.GetComponent<BossMechanic3>().hit();
            }
            if (enemy.tag == "Minor")
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
            if (enemy.tag == "Minion")
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }

        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
