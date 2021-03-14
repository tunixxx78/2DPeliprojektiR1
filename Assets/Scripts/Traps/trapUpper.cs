using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapUpper : baseTrap
{
    [SerializeField] private SpriteRenderer rend;
    [SerializeField] private GameObject kukkaAttack, kukkaDeath;
    //[SerializeField] private Sprite IdlePlant, AtackPlant;
    private Rigidbody2D upperTrap;
    public GameObject ammoSpawner;
    public bool setActive;

    
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
                ammoSpawner.SetActive(false);
                Debug.Log("move");
            }
        }
    }

    protected override void Move()
    {
       if (distanceOfPlayer <= moveRange)
        {
           ChangeState(State.Attack);
            transform.localScale = new Vector3(1f, -trapSize, 1f);
            //rend.sprite = AtackPlant;
            ammoSpawner.SetActive(true);
            kukkaAttack.SetActive(true);

        }
       if (distanceOfPlayer >= moveRange)
        {
            ChangeState(State.Idle);
            transform.localScale = new Vector3(1f, 1f, 1f);
            //rend.sprite = IdlePlant;
            ammoSpawner.SetActive(false);
            kukkaAttack.SetActive(false);

        }
    }

    protected override void Attack()
    {
        if (distanceOfPlayer <= attackRange)
        {
            ChangeState(State.Attack);
            transform.localScale = new Vector3(1f, -trapSize, 1f);
            //rend.sprite = AtackPlant;
            ammoSpawner.SetActive(true);
            kukkaAttack.SetActive(true);
            
        }
    }

    protected override void Die()
    {
        Death();
    }

    public void Death()
    {
        Destroy(gameObject);
        rend.sprite = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ammo"))
        {
            kukkaAttack.SetActive(false);
            kukkaDeath.SetActive(true);
            ScoringSystem.theScore += 25;
            Destroy(gameObject);
            rend.sprite = null;

        }
    }
}
