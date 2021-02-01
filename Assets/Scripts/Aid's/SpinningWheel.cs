using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningWheel : MonoBehaviour
{
    private float rotZ;
    [SerializeField] private float rotSpeed;
    [SerializeField] private bool clockwiseRotation;

    private void Update()
    {
        if (clockwiseRotation == false)
        {
            rotZ += Time.deltaTime * rotSpeed;
        }
        else
        {
            rotZ -= Time.deltaTime * rotSpeed;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
}
