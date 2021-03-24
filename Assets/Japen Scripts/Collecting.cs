using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    [SerializeField] private Transform collecting;

    void OnTriggerEnter2D(Collider2D collision)

    {
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        collecting.GetComponent<ParticleSystem>().Play();
        FMODUnity.RuntimeManager.PlayOneShot("event:/Collecting", GetComponent<Transform>().position);
        ScoringSystem.theScore += 50;
        Destroy(gameObject, 3f);
    }

}
