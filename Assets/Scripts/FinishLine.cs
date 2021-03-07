using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameObject player, clone;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("CloneCharacterLast"))
        {
            ScoringSystem.theScore += 100;
            FindObjectOfType<GameManager>().EndGame();
        }
        if(collision.CompareTag("CloneCharacter"))
        {
            ScoringSystem.theScore += 100;
        }
    }
}
