using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
         public float speed = 5f;
         public float jumpSpeed = 8f;
         private float movement = 0f;
         private Rigidbody2D rigidBody;
         public Transform groundCheckPoint;
         public float groundCheckRadius;
         public LayerMask groundLayer;
         private bool isTouchingGround;

         void Start()
         {
             rigidBody = GetComponent<Rigidbody2D>();
         }

         void Update()
         {
             isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
             movement = Input.GetAxis("Horizontal");
             if (movement > 0f)
             {
                 rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
             }
             else if (movement < 0f)
             {
                 rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
             }
             else
             {
                 rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
             }
             if (Input.GetButtonDown("Jump") && isTouchingGround)
             {
                 rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
             }
         }
    }
