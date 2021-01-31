using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField] private SpriteRenderer rend;
    [SerializeField] private Sprite IdlePlant, AtackPlant;


    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = IdlePlant;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            rend.sprite = AtackPlant;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            rend.sprite = IdlePlant;
        }
    }

    private void Update()
    {
        
    }
}
