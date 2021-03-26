using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverForClones : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Animator helperAnimator;

    [Tooltip("Use True only on first level")]
    public bool helperIcon = false;



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            animator.SetTrigger("vaanto");
            FindObjectOfType<Timer>().StopTimer();

            //in the first level, hides the E icon when player presses E
            if (helperIcon)
            {
                helperAnimator.SetTrigger("end");
            }
        }
    }

    public void RoadToCage()
    {
        FindObjectOfType<CloneCage>().ToCage();
       
    }
}
