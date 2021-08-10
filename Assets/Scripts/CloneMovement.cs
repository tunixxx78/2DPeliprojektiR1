using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 6f;
    [SerializeField] private GameObject cloneDeathCanvas;

    private void FixedUpdate()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        /*if (rb.position.y < -3.5f)
        {
            Destroy(gameObject);
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("TrapAmmo"))
        {
            //Destroy(gameObject);
            cloneDeathCanvas.SetActive(true);
        }
        if (rb.position.y < -2.5f)
        {
            cloneDeathCanvas.SetActive(true);
        }
        if (collision.collider.CompareTag("Enemy"))
        {
            cloneDeathCanvas.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Home"))
        {
            Destroy(gameObject, 0.5f);
            
        }
    }

}
