using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool hasHit;
    private bool Airtime;

    public float lifetime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        if (hasHit == false)
        {
            // /* - Parempi?
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            // */

            // original - float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x * Mathf.Rad2Deg);
            // original - transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;

        if (gameObject.tag == "Missile")
            Destroy(gameObject);
    }
}
