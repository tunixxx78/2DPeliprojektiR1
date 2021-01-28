using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D RB2D;
    private SpriteRenderer myRenderer;
    Animator myAnim;

    private bool canMove = true;

    private bool facingRight = true;

    // move
    public float maxSpeed;

    // jump
    private bool grounded = false;
    private float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpPower;
    
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();
    }

  
    void Update()
    {
        if(canMove && grounded && Input.GetAxis("Jump") > 0)
        {
            myAnim.SetBool("isGrounded", false);
            RB2D.velocity = new Vector2(RB2D.velocity.x, 0f);
            RB2D.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            grounded = false;
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        float move = Input.GetAxis("Horizontal");


        if (canMove)
        {
            if (move > 0 && !facingRight)
                Flip();

            else if (move < 0 && facingRight)
                Flip();

            RB2D.velocity = new Vector2(move * maxSpeed, RB2D.velocity.y);
            myAnim.SetFloat("MoveSpeed", Mathf.Abs(move));
        }
        else
        {
            RB2D.velocity = new Vector2(0, RB2D.velocity.y);
            myAnim.SetFloat("MoveSpeed", 0);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        myRenderer.flipX = !myRenderer.flipX;
    }

    public void toggleCanMove()
    {
        canMove = !canMove;
    }
}
