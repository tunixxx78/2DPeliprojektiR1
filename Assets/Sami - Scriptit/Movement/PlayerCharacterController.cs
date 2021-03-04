using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacterController : MonoBehaviour
{
    
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    [SerializeField] private float sizeMultiplier = 1f; //Turo lisäsi tämän
    [SerializeField] private GameObject player, reStart; //Turo lisäsi tämän

    public float rememberGroundedFor;
    float lastTimeGrounded;

    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    private bool canJump; //Turon lisäyksiä platformilla pysymiseen.

    private void Awake()
    {
        transform.localScale = new Vector3(1f * sizeMultiplier, 1f * sizeMultiplier, 1f); //Turo lisäsi koko metodin
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
        if (Input.GetMouseButtonDown(0))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Shoot", GetComponent<Transform>().position);
        }

    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);

        //flip character
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1f  * sizeMultiplier; // kertoo koon multiplierillä, Turon lisäys.
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1f * sizeMultiplier; // kertoo koon multiplierillä, Turon lisäys.
        }
        transform.localScale = characterScale;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Jump", GetComponent<Transform>().position);
        }
    }

    void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (colliders != null)
        {
            isGrounded = true;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
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
            player.transform.parent = collision.gameObject.transform;
        }
       

    }
    private void OnCollisionExit2D(Collision2D collision)  //Turon lisäämä metodi, pitää hahmon paikallaan platformilla -> muuttaa tilanteen normaaliksi poistumisen jälkeen.
    {
        canJump = false;
        if ( collision.collider.CompareTag("Platform"))
        {
            player.transform.parent = null;
        }
    }
}
