using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapLower : baseTrap
{
    [SerializeField] private SpriteRenderer rend;
    [SerializeField] private Sprite IdlePlant, AtackPlant;
    [SerializeField] private Rigidbody2D lowerTrap;

    protected override void Idle()
    {
        movements = new Vector2(rbtrap.velocity.x, 0f);
        currentIdleTime += Time.deltaTime;

        if (currentIdleTime > maxIdleTime)
        {
            currentIdleTime = 0f;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);

            if (distanceOfPlayer <= visionRange)
            {
                ChangeState(State.Move);
                Debug.Log("move");
            }
        }
    }

    protected override void Move()
    {
        if (distanceOfPlayer <= moveRange)
        {
            ChangeState(State.Attack);
            transform.localScale = new Vector3(1f, trapSize, 1f);
            rend.sprite = AtackPlant;
        }
        if (distanceOfPlayer >= moveRange)
        {
            ChangeState(State.Idle);
            transform.localScale = new Vector3(1f, 1f, 1f);
            rend.sprite = IdlePlant;
        }
    }

    protected override void Attack()
    {
        if (distanceOfPlayer <= attackRange)
        {
            ChangeState(State.Attack);
            Debug.Log("Attack");
        }
    }

    protected override void Die()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ammo"))
        {
            Destroy(gameObject);
            rend.sprite = null;
        }
    }

}
