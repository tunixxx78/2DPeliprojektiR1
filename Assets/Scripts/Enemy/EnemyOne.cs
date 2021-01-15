using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : BaseEnemy
{
    protected override void Agressive()
    {
        
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
}
