﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{

    [SerializeField] private SpriteRenderer rend;
    [SerializeField] private Sprite closedAid, oppenedAid, aid2;
    [SerializeField] private float stairsLenght;
    [SerializeField] private Transform spawnPoint, stairs;
    [SerializeField] private GameObject aid, obstacle;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            stairs.transform.position = spawnPoint.transform.position; 
            transform.localScale = new Vector3(stairsLenght, 1f, 1f);

            Destroy(aid);
        }

        if (collision.collider.CompareTag("Player"))
        {
            obstacle.transform.localScale = new Vector3(0.9f, 0.9f, 1f);
        }
    }

    



}
