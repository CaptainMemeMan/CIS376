using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float moveSpeed = 2.0f; // Speed of enemy movement
    public LayerMask groundLayer; // The layer(s) that represent the ground or platforms

    private Rigidbody2D rb;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move the enemy in the current direction
        Vector2 movement = isFacingRight ? Vector2.right : Vector2.left;
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

        // Check for walls and turn around if a wall is detected
        RaycastHit2D hit = Physics2D.Raycast(transform.position, isFacingRight ? Vector2.right : Vector2.left, 0.5f, groundLayer);
        if (hit.collider != null)
        {
            Flip();
        }
    }

    // Function to flip the enemy's direction
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

}


