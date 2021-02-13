using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 6f;

    private void FixedUpdate()
    {
        transform.position += transform.right * speed * Time.deltaTime;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("TrapAmmo"))
        {
            Destroy(gameObject);
        }
    }

}
