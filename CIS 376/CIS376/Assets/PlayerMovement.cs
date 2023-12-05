using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed; // movement speed
    public Rigidbody2D rb;  //forces to player 

    public float jumpForce = 10f;
    public int extraJump = 0;
    public Transform feet;
    public LayerMask groundLayers;


    private float mx; //movement on the x-axis 
    private bool doubleJumpAllowed;


    private bool Walljumping;
    private float touchingLeftorRight = 1;
    public CoinManager c;

    public GameObject deathMenuUI;
    public Animator anim;
    public float run = 40f;
    float horizontal = 0f;
    private bool facing = true;

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        switchFace();
        if (Input.GetButton("Jump") && IsGrounded())
        {
            Jump(); //calls the jump function  
            doubleJumpAllowed = true;
        }

        else if (Input.GetButton("Jump") && doubleJumpAllowed) //will allow the player to double jump
        {
            Jump();
            doubleJumpAllowed = false;
        }
        if (Walljumping == true)
        {
            rb.velocity = new Vector2(movementSpeed * touchingLeftorRight, jumpForce);

        }


        horizontal = Input.GetAxisRaw("Horizontal") * run;
        anim.SetFloat("speed", Mathf.Abs(horizontal));
    }
    private void FixedUpdate()
    {
        //
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
        rb.velocity = movement;



    }
    void SetJumpingToFalse()
    {
        Walljumping = false;
    }

    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce); //this will allows us to jump
        rb.velocity = movement;



    }
    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);


        if (groundCheck != null)
        {

            return true;
        }
        return false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.gameObject.CompareTag("collectible"))
        {
           Destroy(other.gameObject);
            c.count++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("GameBound"))
        {
            GameOver();
            Debug.Log("Fornite");
        }
    }
    private void GameOver()
    {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    private void switchFace()
    {
        if(facing && horizontal < 0f || !facing && horizontal > 0f)
        {
            facing = !facing;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
