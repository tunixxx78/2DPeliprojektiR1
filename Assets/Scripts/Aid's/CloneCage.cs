using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneCage : MonoBehaviour
{
    [SerializeField] private GameObject camera1;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject clone1, clone2, clone3, clone4, cloneLast, home;

    public void ToCage()
    {
        camera1.SetActive(true);
        animator.SetTrigger("open");
    }

    public void BackToPlayer()
    {
        camera1.SetActive(false);
        clone1.SetActive(true);
        clone2.SetActive(true);
        clone3.SetActive(true);
        clone4.SetActive(true);
        cloneLast.SetActive(true);
        home.SetActive(true);

    }
}
