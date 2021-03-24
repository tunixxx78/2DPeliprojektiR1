using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ammoRb;
    [SerializeField] private float force = 3f;

    [SerializeField] private GameObject hitParticle;

    private bool isQuitting = false;

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
        if (collision.collider.CompareTag("Platform"))
        {
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (collision.collider.CompareTag("CloneCharacter"))
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 5f);
        }
    }

    private void OnDestroy()
    {
        if (!isQuitting)
        {
            if (hitParticle)
            {
                //Spawn projectileparticle where this game object gets destroyed
                GameObject particle = Instantiate(hitParticle, this.transform.position, Quaternion.identity);
                Destroy(particle, 1);
            }
        }
        


    }

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

}
