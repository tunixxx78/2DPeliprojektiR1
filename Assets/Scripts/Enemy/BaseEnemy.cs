using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField]
    protected float health, moveSpeed, moveSpeedAttack, attackPower, maxIdleTime, maxPatrolTime,
                                     visionRange = 5f, attackRange = 2f, agressiveRange;
    protected float distanceOfPlayer, currentIdleTime = 0f, currentPatrolTime = 0f;
    protected bool hasLineOfSight;
    protected Transform player;
    protected Vector2 movements;

    private State enemyState = State.Idle;
    protected Rigidbody2D rbe;
    [SerializeField] protected Animator animator;
    private Action currentStateMethod;

    protected enum State
    {
        Idle,
        Patrol,
        Agressive,
        Death
    }

    private void Awake()
    {
        rbe = GetComponent<Rigidbody2D>();
        currentStateMethod = Idle;
    }

    private void Start()
    {
        player = GameObject.Find("HoodedMageFinalPrefab").transform;
    }

    private void FixedUpdate()
    {
        rbe.velocity = movements;
    }

    private void Update()
    {
        CheckLineOfSight();
        currentStateMethod();

    }

    private void CheckLineOfSight()
    {
        distanceOfPlayer = Vector2.Distance(transform.position, player.transform.position);
        RaycastHit2D raycast = Physics2D.Linecast(transform.position, player.transform.position);

        if (raycast)
        {
            if (distanceOfPlayer < visionRange && enemyState != State.Agressive)
            {
                ChangeState(State.Agressive);

            }
        }

    }

    protected abstract void Idle();
    protected abstract void Patrol();
    protected abstract void Agressive();
    protected abstract void Death();

    protected virtual void ChangeState(State newState)
    {
        enemyState = newState;
        switch(newState)
        {
            case State.Agressive:
                currentStateMethod = Agressive;
                break;
            case State.Patrol:
                currentStateMethod = Patrol;
                break;
            case State.Death:
                currentStateMethod = Death;
                break;
            default:
                currentStateMethod = Idle;
                break;

        }
    } 
}
