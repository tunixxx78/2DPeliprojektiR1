using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextPos;

    [SerializeField] private float speed;

    [SerializeField] private Transform childtransform;

    [SerializeField] private Transform transformB;

    private void Start()
    {
        posA = childtransform.localPosition;
        posB = transformB.localPosition;
        nextPos = posB;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        childtransform.localPosition = Vector3.MoveTowards(childtransform.localPosition, nextPos, speed * Time.deltaTime);

        if (Vector3.Distance(childtransform.localPosition, nextPos) <= 0.1)
        {
            ChangeDestination();
        }
    }
    
    private void ChangeDestination()
    {
        nextPos = nextPos != posA ? posA : posB;
    }
}
