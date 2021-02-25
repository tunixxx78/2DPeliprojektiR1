using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    [SerializeField] public Transform worldEdgeLeft, worldEdgeRight, worldEdgeBottom, worldEdgeUpper;
    public static LayerManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
