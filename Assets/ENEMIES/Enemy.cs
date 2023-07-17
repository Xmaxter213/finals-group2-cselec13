using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 1;
    private Color hitColour;
    private Color neutralColour;

    [SerializeField] SpriteRenderer sprtRndr;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        StartCoroutine(Hit());
        if (currentHealth <= 0)
        {
            this.enabled = false;
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

    private IEnumerator Hit()
    {
        sprtRndr.color = new Color(1, 0, 0, 1f);
        yield return new WaitForSeconds(.2f);
        sprtRndr.color = new Color(1, 1, 1, 1f);

    }
}
