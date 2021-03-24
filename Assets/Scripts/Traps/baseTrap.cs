using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
//[RequireComponent(typeof(Rigidbody2D))]

public abstract class baseTrap : MonoBehaviour
{
    [SerializeField] protected float trapSize, visionRange, moveRange, attackRange, maxIdleTime = 0f;
    protected float distanceOfPlayer, currentIdleTime;
    protected bool hasLineOfSight;
    [SerializeField] protected Transform player;
    protected Vector2 movements;
    [SerializeField] protected GameObject ammoPrefab;
    [SerializeField] protected Transform spawnPointForTrap;
    

    State trapState = State.Idle;
    protected Rigidbody2D rbtrap;
    private Action currentStateMethod;

    protected enum State
    {
        Idle,
        Move,
        Attack,
        Die
    }

    private void Awake()
    {
        rbtrap = GetComponent<Rigidbody2D>();
        currentStateMethod = Idle;
    }

    private void Start()
    {
        player = GameObject.Find("HoodedMageFinalPrefab").transform;
       
    }

    private void FixedUpdate()
    {
        rbtrap.velocity = movements;
    }

    private void Update()
    {
        currentStateMethod();
        CheckLineOfSight();
    }

    

    public void CheckLineOfSight()
    {
        if (player != null)
        {
            distanceOfPlayer = Vector2.Distance(transform.position, player.transform.position);
            RaycastHit2D raycast = Physics2D.Linecast(transform.position, player.transform.position);

            if (raycast)
            {
                if (distanceOfPlayer < visionRange && trapState != State.Move)
                {
                    ChangeState(State.Move);
                }

                if (distanceOfPlayer < attackRange && trapState != State.Attack)
                {
                    ChangeState(State.Attack);
                }
            }
        }
    }

    protected abstract void Idle();
    protected abstract void Move();
    protected abstract void Attack();
    protected abstract void Die();

    protected virtual void ChangeState(State newState)
    {
        trapState = newState;
        switch (newState)
        {
            case State.Move:
                currentStateMethod = Move;
                break;
            case State.Attack:
                currentStateMethod = Attack;
                break;
            case State.Die:
                currentStateMethod = Die;
                break;
            default:
                currentStateMethod = Idle;
                break;
        }
    }
}
