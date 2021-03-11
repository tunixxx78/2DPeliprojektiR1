using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed, deathSpeed;
    public float distance;
    public Rigidbody2D enemyDummy;
    [SerializeField] private Transform deathParticle;
    

    private bool movingRight = true;

    public Transform groundDetection;
    public Animator animator;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        animator.SetBool("isMoving", true);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0f, -180f, 0f);
                movingRight = false;

            }
            else
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                movingRight = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ammo"))
        {
            
            Destroy(gameObject, 2f);
            animator.SetTrigger("death");
            deathParticle.GetComponent<ParticleSystem>().Play();
        }
    }
}
