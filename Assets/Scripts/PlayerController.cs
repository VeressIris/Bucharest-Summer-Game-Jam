using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Ground Check")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask vomitLayer;

    [Header("Movement")]
    public float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 16f;
    private float horizontal;

    private bool facingRight = true;

    [Header("Health")]
    public int health = 3;
    public GameObject[] hearts;

    [Header("Animation")]
    [SerializeField] private Animator anim;

    void Start()
    {
        health = 3;

        //make sure hearts are displayed
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(true);
        }
    }

    void Update()
    {
        //move
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        //animate
        if (IsGrounded())
        {
            if (horizontal != 0) anim.Play("Player Walk2");
            else anim.Play("Idle");
        }
        else anim.Play("Jump");

        //face correct direction
        if (facingRight && horizontal < 0f) Flip();
        else if (!facingRight && horizontal > 0f) Flip();
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (ctx.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        horizontal = ctx.ReadValue<Vector2>().x;
    }

    public bool OnVomit()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, vomitLayer);
    }

    public void TakeDamage()
    {
        if (health > 0)
        {
            health--;
            hearts[health].SetActive(false);
        }
    }
}
