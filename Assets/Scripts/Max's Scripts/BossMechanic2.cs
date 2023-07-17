//using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechanic2 : MonoBehaviour
{
    //game object requirements
    private Rigidbody2D rb;
    private Animator anim;
    public GameObject landingZone;
    public GameObject FlyingZone;
    public GameObject target;
    public GameObject aimPoint;
    public GameObject projectiles;


    //attack time
    public float attackCooldown;
    private float currentADCooldown;

    //everything about hp and invincibility time
    public int maxHp;
    public int currentHp;
    public int invincibility;
    private float invincTime;
    private bool invinc;
    public float landinvinc;
    private float landinvincTime;

    //movement and how fast
    public float speed;
    public float flyingRange;
    public float flightTime;
    private float currentFlightTime;
    private bool isFly;
    private bool isRight;

    //phase 2 harder boss
    private bool phase2;

    [SerializeField] SpriteRenderer sprtRndr;
    private Color hitColour;
    private Color neutralColour;

    [SerializeField] EnterDoor openDoor;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isFlying", false);
        currentADCooldown = attackCooldown;
        isFly = false;
        isRight = true;
        phase2 = false;
        currentHp = maxHp;
        invinc = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentFlightTime--;

        phase();

        // if isFly = true then it will move and become invincible, player must dodge incoming attacks until it flies back down
        if (isFly)
        {
            //keeps him flying animation
            anim.SetBool("isFlying", true);

            //moves to right
            if (isRight)
            {
                // if it is not on the flying zone height, it will try to go there while swaying
                if (this.transform.position.y < FlyingZone.transform.position.y)
                {
                    rb.velocity = new Vector2(speed, speed);
                }
                else
                {
                    rb.velocity = new Vector2(speed, 0);
                }
                if (this.transform.position.x >= FlyingZone.transform.position.x + flyingRange)
                {
                    isRight = false;
                    flip();
                }

            }
            //same thing but left
            if (!isRight)
            {
                if (this.transform.position.y < FlyingZone.transform.position.y)
                {
                    rb.velocity = new Vector2(-speed, speed);
                }
                else
                {
                    rb.velocity = new Vector2(-speed, 0);
                }

                if (this.transform.position.x <= FlyingZone.transform.position.x - flyingRange)
                {
                    isRight = true;
                    flip();
                }
            }

            if (currentADCooldown == 0)
            {
                attack();
                currentADCooldown = attackCooldown;
            }
            else
            {
                currentADCooldown--;
            }

            invincTime--;
            if(invincTime < 0)
            {
                isFly = false;
                landinvincTime = landinvinc;
                currentADCooldown = attackCooldown;
            }

        }
        
        if(!isFly)
        {
            //bring boss back to the landing zone
            if (invinc && anim.GetBool("isFlying"))
            {
                if (Vector2.Distance(landingZone.transform.position, transform.position) > 0.05f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, landingZone.transform.position, speed);
                }
                else
                {
                    rb.velocity = new Vector2(0, 0);
                    anim.SetBool("isFlying", false);
                }
            }

            //start looking for player and attack
            if(transform.position.x > target.transform.position.x && isRight)
            {
                isRight = false;
                flip();
            }
            if(transform.position.x < target.transform.position.x && !isRight)
            {
                isRight = true;
                flip();
            }   

            //start invincibility after falling
            if(invinc)
            {
                if (landinvincTime < 0)
                {
                    invinc = false;
                }
                else
                {
                    landinvincTime--;
                }
            }

            //start attacking
            if(currentADCooldown == 10)
            {
                anim.SetTrigger("attacked");
                currentADCooldown--;
            }
            else
            {
                currentADCooldown--;
            }
            if(currentADCooldown == 0)
            {
                attack();
                currentADCooldown = attackCooldown;
            }

        }
        phase();
    }

    private void phase()
    {
        if (currentHp == maxHp/2 && !phase2)
        {
            phase2 = true;
            attackCooldown = attackCooldown / 2;
            speed = speed * 2;
            invincibility = invincibility * 2;
            landinvinc = landinvinc * 2;
        }
    }

    private void attack()
    {
        if(isFly)
        {
            Debug.Log("flight attack");
            Instantiate(projectiles, new Vector2(target.transform.position.x, landingZone.transform.position.y+5.0f), Quaternion.identity);
        }
        else
        {
            Debug.Log("attack");
            Instantiate(projectiles, aimPoint.transform.position, Quaternion.identity);
        }
    }

    //to flip the image of the enemy and hopefully flip the attack area as well
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        if(isRight)
        {
            aimPoint.transform.position = new Vector2(aimPoint.transform.position.x+1.0f, aimPoint.transform.position.y);
        }
        else
        {
            aimPoint.transform.position = new Vector2(aimPoint.transform.position.x-1.0f, aimPoint.transform.position.y);
        }
    }
     
    public void hit()
    {
        if(!invinc)
        {
            currentHp--;
            StartCoroutine(Hit());
            invinc = true;
            isFly = true;
            invincTime = invincibility;
            if (currentHp == 0)
            {
                Destroy(this.gameObject);
                openDoor.OpenDoor();
            }
        }
    }

    public bool getPhase()
    {
        return phase2;
    }

    public bool getflight()
    {
        return isFly;
    }

    private IEnumerator Hit()
    {
        sprtRndr.color = new Color(1, 0, 0, 1f);
        yield return new WaitForSeconds(.2f);
        sprtRndr.color = new Color(1, 1, 1, 1f);

    }
}
