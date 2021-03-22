using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToReleaseClones : MonoBehaviour
{
    [SerializeField] private GameObject clone1, clone2, clone3, clone4, cloneLast, aid, home;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            clone1.SetActive(true);
        }
        if (collision.CompareTag("Player"))
        {
            clone2.SetActive(true);
        }
        if (collision.CompareTag("Player"))
        {
            clone3.SetActive(true);
        }
        if (collision.CompareTag("Player"))
        {
            clone4.SetActive(true);
        }
        if (collision.CompareTag("Player"))
        {
            cloneLast.SetActive(true);
        }
        if (collision.CompareTag("Player"))
        {
            aid.SetActive(true);
        }
        if (collision.CompareTag("Player"))
        {
            home.SetActive(true);
        }
        else
        {
            return;
        }
    }
}
