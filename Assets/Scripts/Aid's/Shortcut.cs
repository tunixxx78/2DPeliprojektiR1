using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shortcut : MonoBehaviour
{
    [SerializeField] private Transform spawnPointShortcutPlayer, spawnPointShortcutClone;
    [SerializeField] private Transform player, cloneCharacter;

    private bool cloneCharacterIsOverlaping = false;
    private bool PlayerIsOverLaping = false;

    private void Update()
    {
        if (cloneCharacterIsOverlaping)
        {
            cloneCharacter.transform.position = spawnPointShortcutClone.transform.position;
        }
        if (PlayerIsOverLaping)
        {
            player.transform.position = spawnPointShortcutPlayer.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "CloneCharacter")
            {
            cloneCharacterIsOverlaping = true;
            }
        if (other.tag == "Player")
        {
            PlayerIsOverLaping = true;
        }
        /*if (collision.CompareTag("Ammo"))
        {
            player.transform.position = spawnPointShortcut.transform.position;
        }*/

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "CloneCharacter")
        {
            cloneCharacterIsOverlaping = false;
        }
        if (other.tag == "Player")
        {
            PlayerIsOverLaping = false;
        }
    }
}
