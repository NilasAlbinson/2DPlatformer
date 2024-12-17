using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyMovment : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeedE = 3f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(moveSpeedE, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeedE = -moveSpeedE;
        FlipSprite();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeedE = -moveSpeedE;
        FlipSprite();
    }
    void FlipSprite()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
