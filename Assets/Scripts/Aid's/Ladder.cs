using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private float climbSpeed;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKey(KeyCode.W))
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, climbSpeed);
            FindObjectOfType<PlayerCharacterController>().IsClimbing();

        }

        else if (collision.tag == "Player" && Input.GetKey(KeyCode.S))
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -climbSpeed);
            FindObjectOfType<PlayerCharacterController>().IsClimbing();
        }
        else if (collision.tag == "Player")
        {
            FindObjectOfType<PlayerCharacterController>().OnLadder();
        }
        else if (collision.tag != "Player")
        {
            FindObjectOfType<PlayerCharacterController>().Jump();
        }

        else
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0.2f);

        }
    }
    


}
