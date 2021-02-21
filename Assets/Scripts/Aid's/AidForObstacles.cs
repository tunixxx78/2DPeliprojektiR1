using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidForObstacles : MonoBehaviour
{
    [SerializeField] private GameObject aid, aid1, aid2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
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
