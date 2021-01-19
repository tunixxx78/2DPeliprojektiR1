using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10f;

    private void FixedUpdate()
    {
        transform.position += transform.right * speed * Time.deltaTime;

    }

}
