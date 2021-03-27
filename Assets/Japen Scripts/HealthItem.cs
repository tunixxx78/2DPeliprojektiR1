using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField]
    ParticleSystem healthPickupParticle;
    
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Drinking", GetComponent<Transform>().position);
            ScoringSystem.theScore += 150;
            healthPickupParticle.Play();
            Destroy(gameObject, 5);

        }
    }
}
