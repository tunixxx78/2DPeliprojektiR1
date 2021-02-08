using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shortcut : MonoBehaviour
{
    [SerializeField] private Transform spawnPointShortcut;
    [SerializeField] private GameObject player, cloneCharacter;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = spawnPointShortcut.transform.position;
        cloneCharacter.transform.position = spawnPointShortcut.transform.position;
    }
}
