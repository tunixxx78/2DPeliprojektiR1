using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneCageTutorial : MonoBehaviour
{
    [SerializeField] private GameObject camera1;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject text, coin;

    public void ToCage()
    {
        camera1.SetActive(true);
        animator.SetTrigger("open");
    }

    public void BackToPlayer()
    {
        camera1.SetActive(false);
        text.SetActive(true);
        coin.SetActive(true);
    }
}
