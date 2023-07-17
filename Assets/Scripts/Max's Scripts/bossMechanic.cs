using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMechanic : MonoBehaviour
{
    public GameObject target;
    public GameObject attackArea;
    public int maxHp;
    public float speed;
    public GameObject player;
    public Transform teleportTarget;

    private Rigidbody2D rb;
    private Animator anim;
    private int currentHp;
    private float targetPosX;
    private bool phase2;
    private bool isWalk;
    private bool isRight;
    private bool startAttack;

    [SerializeField] SpriteRenderer sprtRndr;
    private Color hitColour;
    private Color neutralColour;

    //Need to disable/destroy, to remove error
    [SerializeField] GameObject bossActivate;

    [SerializeField] EnterDoor openDoor;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isWalking", true);
        isWalk = true;
        startAttack = false;
        isRight = false;
        phase2 = false;
        currentHp = maxHp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            targetPosX = target.transform.position.x;

            phase();

            // if isWalk = true then it will move
            if (isWalk == true)
            {
                //follow player when player is right side
                anim.SetBool("isWalking", true);
                if (targetPosX > this.transform.position.x)
                {
                    rb.velocity = new Vector2(speed, 0);
                    flipChecker();
                }
                //same thing but left
                else
                {
                    rb.velocity = new Vector2(-speed, 0);
                    flipChecker();
                }
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
                anim.SetBool("isWalking", false);
            }
        }
    }

    private void phase()
    {
        if (currentHp == maxHp / 2 && phase2 == false)
        {
            speed = speed * 2;
            phase2 = true;
            anim.SetFloat("speed", 2);
        }
    }
    
    private void attack()
    {
        Debug.Log("Attacked");
        if (attackArea.GetComponent<AttackChecker>().checker())
        { 
            StartCoroutine(Swing());

            //if hit, it does this.
            Debug.Log("you got hit");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !startAttack)
        {
            if (phase2)
            {
                StartCoroutine(attack2());
            }
            else
            {
                StartCoroutine(attack1());
            }
        }
    }

    //check if it should flip, if yes then it will
    private void flipChecker()
    {
        if (targetPosX > this.transform.position.x)
        {
            if (isRight != true)
            {
                flip();
                isRight = true;
            }
        }
        //same thing but left
        else
        {
            if (isRight != false)
            {
                flip();
                isRight = false;
            }
        }
    }

    //code to flip
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    //code if hit by player
    
    public void hit()
    {
        currentHp--;
        StartCoroutine(Hit());
        if (currentHp == 0)
        {
            Destroy(this.bossActivate);
            Destroy(this.gameObject);
            openDoor.OpenDoor();
        }
    }
    

    private IEnumerator attack1()
    {
        startAttack = true;
        isWalk = false;
        anim.SetBool("isAttacking", true);
        Debug.Log("attack animation start");
        yield return new WaitForSeconds(0.25f);
        Debug.Log("attack touches ground");
        anim.SetBool("isAttacking", false);
        attack();
        yield return new WaitForSeconds(0.25f);
        Debug.Log("attack ends");
        yield return new WaitForSeconds(0.75f);
        Debug.Log("croco starts moving");
        startAttack = false;
        isWalk = true;
    }
    private IEnumerator attack2()
    {
        startAttack = true;
        isWalk = false;
        anim.SetBool("isAttacking", true);
        Debug.Log("attack animation start");
        yield return new WaitForSeconds(0.25f);
        Debug.Log("attack touches ground");
        anim.SetBool("isAttacking", false);
        attack();
        yield return new WaitForSeconds(0.25f);
        anim.SetBool("isAttacking", true);
        Debug.Log("attack animation start");
        flipChecker();
        yield return new WaitForSeconds(0.25f);
        Debug.Log("attack touches ground");
        anim.SetBool("isAttacking", false);
        attack();
        yield return new WaitForSeconds(0.25f);
        anim.SetBool("isAttacking", true);
        Debug.Log("attack animation start");
        flipChecker();
        yield return new WaitForSeconds(0.25f);
        Debug.Log("attack touches ground");
        anim.SetBool("isAttacking", false);
        attack();
        yield return new WaitForSeconds(0.25f);
        Debug.Log("attack ends");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("croco starts moving");
        startAttack = false;
        isWalk = true;
    }

    private IEnumerator Swing()
    {
        yield return new WaitForSeconds(.1f);
        player.transform.position = teleportTarget.transform.position;
    }



    private IEnumerator Hit()
    {
        sprtRndr.color = new Color(1, 0, 0, 1f);
        yield return new WaitForSeconds(.2f);
        sprtRndr.color = new Color(1, 1, 1, 1f);

    }
}