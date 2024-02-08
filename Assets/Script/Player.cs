using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;
    private bool isFacingRight;
    private Vector2 startPos;
    private bool hasGravityBelt;

    [SerializeField] private int lifes, score;

    [SerializeField] private GameManager gameManager;
    [SerializeField] float speed;
    [SerializeField] float jump;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer, boxLayer;
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        isFacingRight = true;
        hasGravityBelt = false;
        GUI.lifes = lifes;
        GUI.score = score;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jump*((float)rb.gravityScale));
            }
        }

        animator.SetFloat("speed", Math.Abs(rb.velocity.x));
        animator.SetFloat("y_speed", Math.Abs(rb.velocity.y));
        animator.SetBool("isGrounded", isGrounded());

        Flip();
        FlipGravity();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.01f, groundLayer) || Physics2D.OverlapCircle(groundCheck.position, 0.01f, boxLayer);
    }


    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0)
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
    private void FlipGravity()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && hasGravityBelt)
        {
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
            rb.gravityScale *= -1;
        }
    }

    public void Die()
    {
        if(lifes > 1)
        {
            lifes--;
        } else if (lifes <= 1)
        {
            gameManager.GameOver();
        }
        GUI.lifes = lifes;
        Respawn();
    }

    public void Respawn()
    {
        rb.gravityScale = 1f;
        rb.velocity = Vector3.zero;
        transform.position = startPos;
        transform.localScale = Vector3.one;
        isFacingRight = true;
        
    }

    public void AcquireGravityBelt()
    {
        hasGravityBelt = true;
    }

    public void increaseScore(int amount)
    {
        score += amount;
        GUI.score = score;
    }
}
