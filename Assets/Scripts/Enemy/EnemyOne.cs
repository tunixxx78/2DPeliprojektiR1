using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : BaseEnemy
{
    //[SerializeField] private Rigidbody2D enemyOne;

    protected override void Agressive()
    {
        if (distanceOfPlayer <= attackRange)
        {
            ChangeState(State.Agressive);
        }

        float direction = Mathf.Sign(player.transform.position.x - transform.position.x);

        transform.localScale = new Vector3(direction * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        movements = new Vector2(transform.localScale.x * moveSpeedAttack, rbe.velocity.y);

        if (distanceOfPlayer >= attackRange)
        {
            ChangeState(State.Idle);
        }


    }

    protected override void Patrol()
    {
        movements = new Vector2(transform.localScale.x * moveSpeed, rbe.velocity.y);

        currentPatrolTime += Time.deltaTime;

        if(currentPatrolTime >= maxPatrolTime)
        {
            currentPatrolTime = 0f;
            ChangeState(State.Idle);

        }
    }

    protected override void Death()
    {
        
    }

    protected override void Idle()
    {
        movements = new Vector2(0f, rbe.velocity.y);

        currentIdleTime += Time.deltaTime;

        if (currentIdleTime > maxIdleTime)
        {
            currentIdleTime = 0f;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            ChangeState(State.Patrol);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ammo"))
        {
            ScoringSystem.theScore += 35;
            Destroy(gameObject);
        }
    }
}
