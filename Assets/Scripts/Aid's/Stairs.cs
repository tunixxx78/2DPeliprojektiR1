using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{

    [SerializeField] private SpriteRenderer rend;
    [SerializeField] private float stairsLenght;
    [SerializeField] private Transform spawnPoint, stairs;
    [SerializeField] private GameObject aid, aid2, obstacle, vineBridge;
    [SerializeField] private bool setActive;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            stairs.transform.position = spawnPoint.transform.position; 
            transform.localScale = new Vector3(stairsLenght, 1f, 1f);
            //vineBridge.SetActive(true);
            Destroy(aid2);
            Destroy(aid);
            
        }
        else
        {
            return;
        }

        if (collision.collider.CompareTag("Player"))
        {
            obstacle.transform.localScale = new Vector3(0.4f, 0.4f, 1f);
        }
        else
        {
            return;
        }

        
    }

    



}
