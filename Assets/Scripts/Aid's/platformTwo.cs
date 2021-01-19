﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformTwo : baseMovingPlatform
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("LeftPoint"))
        {
            ChangeState(State.Idle2);

        }
        else
        {
            ChangeState(State.Idle);
        }
    }

    protected override void PatrolUp_Right()
    {
        Movements = new Vector2(transform.localScale.x * moveSpeed, rbPlatform.velocity.y);


        currentPatrolTime += Time.deltaTime;

        if (currentPatrolTime >= maxPatrolTime)
        {
            currentPatrolTime = 0f;
            ChangeState(State.Idle);
        }


    }
    protected override void PatrolDown_Left()
    {
        Movements = new Vector2(-transform.localScale.x * moveSpeed, rbPlatform.velocity.y);

        currentPatrolTime += Time.deltaTime;

        if (currentPatrolTime >= maxPatrolTime)
        {
            currentPatrolTime = 0f;
            ChangeState(State.Idle2);

        }
    }



    protected override void Idle()
    {
        Movements = new Vector2(0f, rbPlatform.velocity.x);
        currentIdleTime += Time.deltaTime;

        if (currentIdleTime > maxIdleTime)
        {
            currentIdleTime = 0f;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
            ChangeState(State.PatrolDown_Left);


        }
    }

    protected override void Idle2()
    {
        Movements = new Vector2(0f, rbPlatform.velocity.y);
        currentIdleTime += Time.deltaTime;

        if (currentIdleTime > maxIdleTime)
        {
            currentIdleTime = 0f;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
            ChangeState(State.PatrolUp_Right);


        }
    }

}