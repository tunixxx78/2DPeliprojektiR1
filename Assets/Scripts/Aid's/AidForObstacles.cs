using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidForObstacles : MonoBehaviour
{
    [SerializeField] private GameObject aid, aid1, aid2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(aid);
            Destroy(aid1);
            Destroy(aid2);
        }
        else
        {
            return;
        }
    }
}
