using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverForClonesTutorial : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject text;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            animator.SetTrigger("vaanto");
            
        }
    }

    public void RoadToCage()
    {
        FindObjectOfType<CloneCageTutorial>().ToCage();
        text.SetActive(false);
    }
}
