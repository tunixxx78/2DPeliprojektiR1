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

    private State aidState = State.Patrol;
    private Action currentStateMethod;

    protected enum State
    {
        Idle,
        Patrol
    }

    private void Awake()
    {
        rbPlatform = GetComponent<Rigidbody2D>();
        currentStateMethod = Patrol;
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
    protected abstract void Patrol();

    protected virtual void ChangeState(State newState)
    {
        aidState = newState;

        switch(newState)
        {
            case State.Patrol:
                currentStateMethod = Patrol;
                break;
            default:
                currentStateMethod = Idle;
                break;
        }
    }
}
