using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoMovement : MonoBehaviour
{
    private Rigidbody2D ammoRb;
    [SerializeField] private float speed = 10f;

    private void FixedUpdate()
    {
        transform.position += -transform.right * speed * Time.deltaTime;
        Destroy(gameObject, 10f);
    }


}
