using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public CharacterHealth health;

    private float moveDir;
    private bool canJump;
    private bool isFacingRight = true;
    private bool isGrounded;
    private bool isRunning;
    private bool isJumping;

    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float jumpForce = 3f;
    [SerializeField] float radius;
    [SerializeField] LayerMask groundLayer;

    public Transform groundCheck;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckSurroundings();
        CheckInput();
        CheckMovementDirection();
        UpdateAnimation();
        Jump();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void CheckInput()
    {
        moveDir = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 5f;
            isRunning = true;
        }
        else
        {
            moveSpeed = 2f;
            isRunning = false;
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }

    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, groundLayer);
    }

    private void ApplyMovement()
    {
        rb.velocity = new Vector2(moveDir * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        if (canJump)
        {
            isJumping = true;

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else
        {
            isJumping = false;
        }
    }

    private void UpdateAnimation()
    {
        anim.SetFloat("Walk", Mathf.Abs(moveDir));
        anim.SetBool("IsRunning", isRunning);
        //anim.SetBool("IsJumping", isJumping);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            health.TakeDamage(5);
        }
    }

    private void CheckMovementDirection()
    {
        if (isFacingRight && moveDir < 0)
        {
            Flip();
        }
        else if (!isFacingRight && moveDir > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }
}
