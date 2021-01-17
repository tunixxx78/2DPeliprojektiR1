using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float moveSpeed, climbSpeed, jumpForce, distance;
    [SerializeField] GameObject Player;
    [SerializeField] private LayerMask whatIsLadder;
    private float xMovements, yMovements;
    private Rigidbody2D rbchar;
    private bool isJumping, canJump;
    private bool isClimbing;

    private void Awake()
    {
        rbchar = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        rbchar.AddForce(Vector2.right * moveSpeed * xMovements - rbchar.velocity);
        if (isJumping && canJump)
        {
            rbchar.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

        if (hitInfo.collider != null)
        {
            if (Input.GetKey(KeyCode.W))
            {
                isClimbing = true;
            }
            else
            {
                isClimbing = false;
            }
        }
        if (isClimbing == true)
        {
            yMovements = Input.GetAxisRaw("Vertical");
            rbchar.velocity = new Vector2(rbchar.velocity.x, yMovements * climbSpeed);
            rbchar.gravityScale = 0f;
        }
        else
        {
            rbchar.gravityScale = 1f;
        }

    }

    private void Update()
    {
        xMovements = Input.GetAxisRaw("Horizontal");
        isJumping = Input.GetAxisRaw("Jump") > 0f;

        if (xMovements != 0f)
        {
            transform.localScale = new Vector3(0.4f * xMovements, 0.4f, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        if (collision.collider.CompareTag("Platform"))
        {
            Player.transform.parent = collision.gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
        if (collision.collider.CompareTag("Platform"))
        {
            Player.transform.parent = null;
        }
    }
}
