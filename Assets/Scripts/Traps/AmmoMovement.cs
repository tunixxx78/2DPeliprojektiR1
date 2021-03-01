using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ammoRb;
    [SerializeField] private float force = 3f;

    private void Awake()
    {
        GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        transform.position += -transform.right * force * Time.deltaTime;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (collision.collider.CompareTag("CloneCharacter"))
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 3f);
        }
    }

}
