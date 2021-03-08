using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningClonesInIntro : MonoBehaviour
{
    [SerializeField] private Transform row1, row2;
    [SerializeField] private Transform plr, plr2, plr3, plr4, plr5, plr6;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("1"))
        {
            plr.transform.position = row1.transform.position;
        }
        if (collision.CompareTag("2"))
        {
            plr2.transform.position = row2.transform.position;
        }
        if (collision.CompareTag("3"))
        {
            plr3.transform.position = row1.transform.position;
        }
        if (collision.CompareTag("4"))
        {
            plr4.transform.position = row2.transform.position;
        }
        if (collision.CompareTag("5"))
        {
            plr5.transform.position = row1.transform.position;
        }
        if (collision.CompareTag("6"))
        {
            plr6.transform.position = row2.transform.position;
        }
        else
        {
            return;
        }

    }
}
