using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouch : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnColllisionEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            player.transform.parent = collision.gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            player.transform.parent = null;
        }
    }
}
