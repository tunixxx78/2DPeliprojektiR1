using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)

    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Collecting", GetComponent<Transform>().position);
        ScoringSystem.theScore += 50;
        Destroy(gameObject);
    }

}
