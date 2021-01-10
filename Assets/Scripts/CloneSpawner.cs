using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSpawner : MonoBehaviour
{
    ClonePooler clonePooler;

    private void Start()
    {
        clonePooler = ClonePooler.Instance;
    }

    private void FixedUpdate()
    {
        clonePooler.SpawnFromPool("Clone", transform.position, Quaternion.identity);
    }
}
