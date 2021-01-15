using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]

public abstract class baseMovingPlatform : MonoBehaviour
{
    [SerializeField] protected float moveSpeed, maxPatrolTime, maxIdleTime;
    protected float currentIdleTime = 0f, currentPatrolTime = 0f;
    protected Rigidbody2D rbPlatform;
    protected Vector2 Movements;
    protected bool hasPassanger;
    protected Transform player;

    private State aidState = State.PatrolUp_Right;
    private Action currentStateMethod;

    protected enum State
    {
        Idle,
        Idle2,
        PatrolUp_Right,
        PatrolDown_Left
    }

    private void Awake()
    {
        rbPlatform = GetComponent<Rigidbody2D>();
        currentStateMethod = PatrolUp_Right;
    }

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        rbPlatform.velocity = Movements;
    }

    private void Update()
    {
        currentStateMethod();
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            ChangeState(State.Idle);
        }
    }

    protected abstract void Idle();
    protected abstract void Idle2();
    protected abstract void PatrolUp_Right();
    protected abstract void PatrolDown_Left();

    protected virtual void ChangeState(State newState)
    {
        aidState = newState;

        switch(newState)
        {
            case State.PatrolUp_Right:
                currentStateMethod = PatrolUp_Right;
                break;
            case State.PatrolDown_Left:
                currentStateMethod = PatrolDown_Left;
                break;
            case State.Idle2:
                currentStateMethod = Idle2;
                break;
            default:
                currentStateMethod = Idle;
                break;
        }
    }
}
