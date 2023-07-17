using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class nakarProjectile : MonoBehaviour
{
    private GameObject owner;
    private GameObject aimPoint;
    public Rigidbody2D rb;
    //public GameObject player;

    private GameObject teleportTarget;
    public float lifespan;
    private float currentLifeSpan;
    private bool isRight;
    public float speed;
    private bool comeBack;


    // Start is called before the first frame update
    void Start()
    {
        currentLifeSpan = lifespan;

        owner = GameObject.Find("Nakar");
        aimPoint = GameObject.Find("AimPoint");
        comeBack = false;

        if (aimPoint.transform.position.x < owner.transform.position.x)
        {
            isRight = false;
        }
        else
        {
            isRight = true;
        }

        if(owner.GetComponent<BossMechanic2>().getPhase())
        {
            speed = speed * 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(owner)
        {
            if(!owner.GetComponent<BossMechanic2>().getPhase())
            {
                currentLifeSpan--;
                if (currentLifeSpan < 0.0f)
                {
                    Destroy(this.gameObject);
                }

                if(!owner.GetComponent<BossMechanic2>().getflight())
                {
                    //summon to go left
                    if (isRight)
                    {
                        rb.velocity = new Vector2(speed, 0);
                    }
                    if (!isRight)
                    {
                        rb.velocity = new Vector2(-speed, 0);
                    }
                }
                else
                {
                    rb.velocity = new Vector2(0, -speed*3);
                }
            }
            else
            {
                currentLifeSpan--;
                if (currentLifeSpan < 0.0f)
                {
                    Destroy(this.gameObject);
                }
                if (!owner.GetComponent<BossMechanic2>().getflight())
                {
                    if (!comeBack)
                    {
                        if (isRight)
                        {
                            rb.velocity = new Vector2(speed, 0);
                        }
                        if (!isRight)
                        {
                            rb.velocity = new Vector2(-speed, 0);
                        }
                        if (Vector2.Distance(transform.position, owner.transform.position) > 10.0f)
                        {
                            comeBack = true;
                        }
                    }
                    else
                    {
                        if (isRight)
                        {
                            rb.velocity = new Vector2(-speed, 0);
                        }
                        if (!isRight)
                        {
                            rb.velocity = new Vector2(speed, 0);
                        }
                        if (Vector2.Distance(transform.position, owner.transform.position) < 0.5f || owner.GetComponent<BossMechanic2>().getflight())
                        {
                            Destroy(this.gameObject);
                        }
                    }
                }
                else
                {
                    rb.velocity = new Vector2(0, -speed*3);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            teleportTarget = GameObject.Find("Boss Respawn");
            if(teleportTarget)
            collision.transform.position = teleportTarget.transform.position;
        }
    }
}
