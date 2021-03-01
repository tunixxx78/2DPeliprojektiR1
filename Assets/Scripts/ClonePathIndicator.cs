using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonePathIndicator : MonoBehaviour
{
    [SerializeField] private GameObject indicator;

    public void PathIndicator()
    {
        indicator.SetActive(false);
    }
}
