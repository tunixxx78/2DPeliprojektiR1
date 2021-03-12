using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutJape : MonoBehaviour
{
    [SerializeField] private Transform spawnPointShortcutPlayer, spawnPointShortcutClone;
    [SerializeField] private Transform player, cloneCharacter, cloneCharacter1, cloneCharacter2, cloneCharacter3, cloneCharacter4;

    private bool cloneCharacterIsOverlaping = false;
    private bool cloneCharacter1IsOverlaping = false;
    private bool cloneCharacter2IsOverlaping = false;
    private bool cloneCharacter3IsOverlaping = false;
    private bool cloneCharacter4IsOverlaping = false;
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
        if (cloneCharacter1IsOverlaping)
        {
            cloneCharacter1.transform.position = spawnPointShortcutClone.transform.position;


        }
        if (cloneCharacter2IsOverlaping)
        {
            cloneCharacter2.transform.position = spawnPointShortcutClone.transform.position;

        }
        if (cloneCharacter3IsOverlaping)
        {
            cloneCharacter3.transform.position = spawnPointShortcutClone.transform.position;

        }
        if (cloneCharacter4IsOverlaping)
        {
            cloneCharacter4.transform.position = spawnPointShortcutClone.transform.position;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "CloneCharacter")
        {
            cloneCharacterIsOverlaping = true;
        }
        if (other.tag == "CloneCharacter1")
        {
            cloneCharacter1IsOverlaping = true;
        }
        if (other.tag == "CloneCharacter2")
        {
            cloneCharacter2IsOverlaping = true;
        }
        if (other.tag == "CloneCharacter3")
        {
            cloneCharacter3IsOverlaping = true;
        }
        if (other.tag == "CloneCharacterLast")
        {
            cloneCharacter4IsOverlaping = true;
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
        if (other.tag == "CloneCharacter1")
        {
            cloneCharacter1IsOverlaping = false;
        }
        if (other.tag == "CloneCharacter2")
        {
            cloneCharacter2IsOverlaping = false;
        }
        if (other.tag == "CloneCharacter3")
        {
            cloneCharacter3IsOverlaping = false;
        }
        if (other.tag == "CloneCharacterLast")
        {
            cloneCharacter4IsOverlaping = false;
        }
        if (other.tag == "Player")
        {
            PlayerIsOverLaping = false;
        }
    }
}