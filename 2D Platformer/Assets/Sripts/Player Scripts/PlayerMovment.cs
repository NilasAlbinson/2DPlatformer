using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] ContactFilter2D groundFilter;
    bool isGrounded = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
            moveInput = value.Get<Vector2>();
    }

    void OnJump()
    {
        if (isGrounded)
        {
            rb.velocity += new Vector2(0f, jumpSpeed);

        }
        else
        {
            FindFirstObjectByType<GameSession>().InitiateJump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            if (isGrounded == true)
            {
                FindFirstObjectByType<GameSession>().ResetNumJumps();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            if (isGrounded == true)
            {
                FindFirstObjectByType<GameSession>().ResetNumJumps();
            }
        }
    }

    private void FixedUpdate()
    {
        isGrounded = rb.IsTouching(groundFilter);
    }

    void Update()
    {
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
    }
}
