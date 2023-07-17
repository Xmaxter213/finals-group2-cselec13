using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    public GameObject player;
    private float speed;
    private float distanceBetween;
    public Transform teleportTarget;

    private float distance;
    [SerializeField] SpriteRenderer spriteRend;

    private void Start()
    {
        speed = 2f;

        distanceBetween = 3;
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (distance < distanceBetween)
        { 
            StartCoroutine(Detected());  
        }
    }

    // DAMAGERERER  \/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.transform.position = teleportTarget.transform.position;
            Destroy(this.gameObject);
        }
    }
    private IEnumerator Detected()
    {
        yield return new WaitForSeconds(.5f);
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

    }
}
