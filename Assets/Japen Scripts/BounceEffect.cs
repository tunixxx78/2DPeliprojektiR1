﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceEffect : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private Rigidbody2D rb;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tramp"))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
