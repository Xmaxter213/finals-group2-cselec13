using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 4f;
    private float jumpingPower = 10f;
    private bool isFacingRight = true;

    //private bool doubleJump;

    public bool isMoving;
    public bool isJumping;

    public Animator anim;

    public SpriteRenderer sprite;
    //coyote time just makes jumping in the game a bit smoother
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    //private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    //DASH
    [Header("Dashing")]
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 12.5f;
    private float dashingTime = 0.125f;
    private float dashingCD = 0.25f;
    //DOUBLE JUMPING (or triple, quad jumping)
    private int extraJumps;
    public int extraJumpsValue;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        extraJumps = extraJumpsValue;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        //rb.velocity = new Vector2(dirX * 8f, rb.velocity.y);

        if (isDashing)
        {
            return;
        }

        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumpBufferCounter = 0f;
        }

        //TESTING NEW JUMP CODE CHUCHU
        if(IsGrounded() == true)
        {
            extraJumps = extraJumpsValue;
        } 
        if(Input.GetButtonDown("Jump") && extraJumps >0)
        {
            rb.velocity = Vector2.up * jumpingPower;
            extraJumps--;
        }
        else if (Input.GetButtonDown("Jump") && extraJumps ==0 && IsGrounded() == true) 
        {
            rb.velocity = Vector2.up * jumpingPower;
        }

        //DASHING
        if (Input.GetButtonDown("Dash") && canDash)
        {
            StartCoroutine(Dash());
        }
        //FLIP CHAR SPRITE 
        //if (horizontal < 0 && !isFacingRight)
        //{
        //    Flip();
        //}
        //else if (horizontal < 0 && isFacingRight)
        //{
        //    Flip();
        //}
        Flip();
    }

    //collission thingy for jumping
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (Input.GetButtonDown("Horizontal"))
        {
            isMoving = true;
            anim.SetBool("IsMoving", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            isMoving = true;
            anim.SetBool("IsMoving", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            isMoving = true;
            anim.SetBool("IsMoving", true);
        }
        if (!Input.anyKey)
        {
            isMoving = false;
            anim.SetBool("IsMoving", false);
        }
        //JUMPING
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            anim.SetBool("IsJumping", true);
        }
        if(!Input.anyKey)
        {
            isJumping = false;
            anim.SetBool("IsJumping", false);
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCD);
        canDash = true;
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {

            isFacingRight = !isFacingRight;

            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

            //transform.Rotate(0f, 180f, 0f);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
