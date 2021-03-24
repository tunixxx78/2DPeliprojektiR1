using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverHelperScript : MonoBehaviour
{
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Animator>().SetTrigger("start");
        }
    }

    public void hideHelper()
    {
        GetComponent<Animator>().SetTrigger("end");
    }
}
