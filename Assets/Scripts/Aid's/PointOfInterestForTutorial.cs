using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterestForTutorial : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void OnTriggerEnter2D(Collider2D collision)

    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Collecting", GetComponent<Transform>().position);
        //ScoringSystem.theScore += 50;
        animator.SetTrigger("destroy");
        Destroy(gameObject, 1f);
    }
}
