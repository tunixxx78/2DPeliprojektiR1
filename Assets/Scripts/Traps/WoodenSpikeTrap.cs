using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenSpikeTrap : MonoBehaviour
{
    [SerializeField] private Transform tryAgainSpawn;
    [SerializeField] private Transform player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player.transform.position = tryAgainSpawn.transform.position;
        }
        else
        {
            return;
        }
    }
}
