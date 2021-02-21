using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToShowSomething : MonoBehaviour
{
    [SerializeField] private GameObject toShow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            toShow.SetActive(true);
        }
    }
}
