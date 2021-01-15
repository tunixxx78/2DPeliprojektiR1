using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformOne : baseMovingPlatform
{
    protected override void Patrol()
    {
        Movements = new Vector2(rbPlatform.velocity.x, transform.localScale.y * moveSpeed);
        currentPatrolTime += Time.deltaTime;

        if ( currentPatrolTime >= maxPatrolTime)
        {
            currentPatrolTime = 0f;
            ChangeState(State.Idle);
        }
    }

    protected override void Idle()
    {
        Movements = new Vector2(rbPlatform.velocity.x, 0f);
        currentIdleTime += Time.deltaTime;

        if (currentIdleTime > maxIdleTime)
        {
            currentIdleTime = 0f;
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
            ChangeState(State.Patrol);

        }
    }
}
