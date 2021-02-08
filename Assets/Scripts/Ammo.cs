using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    //[SerializeField] private Rigidbody2D ammo;
    [SerializeField] private float speed = 200f;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        
    }
}
