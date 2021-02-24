using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToShowSomething : MonoBehaviour
{
    [SerializeField] private GameObject toShow, toShowToo, alsoShow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            toShow.SetActive(true);
        }
        if (collision.CompareTag("Player"))
        {
            toShowToo.SetActive(true);
        }
        if (collision.CompareTag("Player"))
        {
            alsoShow.SetActive(true);
        }
        else
        {
            return;
        }
    }
}
