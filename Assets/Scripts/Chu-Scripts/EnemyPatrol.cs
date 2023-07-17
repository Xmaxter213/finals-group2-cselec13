using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1.0f;

    Rigidbody2D EnemyRigidBody;
    BoxCollider2D EnemyBoxColider;



    // Start is called before the first frame update
    void Start()
    {
        EnemyRigidBody = GetComponent<Rigidbody2D>();
        EnemyBoxColider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ifLookingRight())
        {
            EnemyRigidBody.velocity = new Vector2(moveSpeed, 0.0f);
        }
        else
        {
            EnemyRigidBody.velocity = new Vector2(-moveSpeed, 0.0f);
        }

    }

    private bool ifLookingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(EnemyRigidBody.velocity.x)),transform.localScale.y);
    }
}
