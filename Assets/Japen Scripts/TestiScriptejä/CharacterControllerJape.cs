﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControllerJape : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    [SerializeField] private float sizeMultiplier = 1f; //Turo lisäsi tämän
    [SerializeField] private GameObject player, reStart; //Turo lisäsi
    [SerializeField] private Animator animator;
    [SerializeField] public GameObject canvasBoard;

    public int extraJumps = 1;
    int jumpCount = 0;
    float jumpCooldown;







    public float rememberGroundedFor;
    float lastTimeGrounded;

    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;


    private bool canJump; //Turon lisäyksiä platformilla pysymiseen.

    private void Awake()
    {

        transform.localScale = new Vector3(0.15f * sizeMultiplier, 0.15f * sizeMultiplier, 1f); //Turo lisäsi koko metodin

    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        Move();
        Jump();
        BetterJump();
        CheckIfGrounded();
        HasFallen();                    // Turon Lisäys



        if (Input.GetKeyDown(KeyCode.Escape))  //Turon lisäys exitille pelistä.
        {
            SceneManager.LoadScene("StartScreen");
        }
        if (Input.GetMouseButtonDown(0)) //Turon lisäys ampuma äänelle.
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Shoot", GetComponent<Transform>().position);
            animator.SetTrigger("Attack");
        }


    }



    void Move()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);

        animator.SetBool("runAnim", x != 0f);

        //flip character
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = 0.15f * sizeMultiplier; // kertoo koon multiplierillä, Turon lisäys.
            canvasBoard.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = -0.15f * sizeMultiplier; // kertoo koon multiplierillä, Turon lisäys.
            canvasBoard.transform.localScale = new Vector3(-0.01f, 0.01f, 0.01f);
        }
        transform.localScale = characterScale;





    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("InAir", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || jumpCount < extraJumps))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
            animator.SetBool("InAir", true);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Jump", GetComponent<Transform>().position);
        }
        else
        {
            //animator.SetBool("InAir", false);

        }
        CheckIfGrounded();
    }

    void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (colliders != null)
        {
            isGrounded = true;
            jumpCount = 0;
            jumpCooldown = Time.time + 0.2f;
            animator.SetBool("InAir", false);

        }
        else if (Time.time < jumpCooldown)
        {
            isGrounded = true;
        }
        else
        {
            /* if (isGrounded)
             {
                 lastTimeGrounded = Time.time;
             }*/
            isGrounded = false;
            animator.SetBool("runAnim", false);
        }
    }

    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void HasFallen()
    {
        if (rb.position.y < -2.5f)      //Turo lisäsi tarkistuksen onko hahmo tippunut.
        {
            FindObjectOfType<GameManager>().Invoke("Restart", 0.5f);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)  //Turon lisäämä metodi, pitää hahmon paikallaan platformilla
    {
        canJump = true;
        if (collision.collider.CompareTag("Platform"))
        {
            var emptyObject = new GameObject();
            emptyObject.transform.parent = collision.gameObject.transform;  //luodaan tyhjä child objecti platformille ja tehdään pelaajasta tyhjän objektin
            player.transform.parent = emptyObject.transform;                //childi jolloin pelaaja perii välittömän vanhemman koon eikä platformin kokoa
        }                                                                   //fixi scale bugille kun hyppäsi liikkuvalle platformille. Japen Liäsys


    }
    private void OnCollisionExit2D(Collision2D collision)  //Turon lisäämä metodi, pitää hahmon paikallaan platformilla -> muuttaa tilanteen normaaliksi poistumisen jälkeen.
    {
        canJump = false;
        if (collision.collider.CompareTag("Platform"))
        {
            player.transform.parent = null;

        }
    }
}
