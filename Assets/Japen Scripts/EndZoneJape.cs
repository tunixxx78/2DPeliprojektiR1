using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZoneJape : MonoBehaviour
{
    [SerializeField] private GameObject player, clone, clone1, clone2, clone3, clone4;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CloneCharacterLast"))
        {
            ScoringSystem.theScore += 100;
            
        }
        if (collision.CompareTag("CloneCharacter1"))
        {
            ScoringSystem.theScore += 100;
        }
        if (collision.CompareTag("CloneCharacter2"))
        {
            ScoringSystem.theScore += 100;
        }
        if (collision.CompareTag("CloneCharacter3"))
        {
            ScoringSystem.theScore += 100;
        }
        if (collision.CompareTag("CloneCharacter"))
        {
            ScoringSystem.theScore += 100;
        }
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Collided");
            FindObjectOfType<GameManager>().EndGame();
        }

    }
}
