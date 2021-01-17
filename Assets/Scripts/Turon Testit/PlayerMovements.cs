using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float moveSpeed, jumpForce;
    [SerializeField] GameObject Player;

    private float xMovements;
    private Rigidbody2D rbchar;
    private bool isJumping, canJump;

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
