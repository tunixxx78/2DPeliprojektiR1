using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)

    {
        ScoringSystem.theScore += 50;
        Destroy(gameObject);
    }

}
