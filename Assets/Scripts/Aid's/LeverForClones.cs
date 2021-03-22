using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverForClones : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            animator.SetTrigger("vaanto");
        }
    }

    public void RoadToCage()
    {
        FindObjectOfType<CloneCage>().ToCage();
    }
}
