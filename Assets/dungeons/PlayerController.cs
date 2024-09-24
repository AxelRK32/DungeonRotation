using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float maxSpeed = 5;

    [Header("Jump")]
    public float jumpPower = 6;

    Rigidbody2D rb2D;
    float xVelocity;
    bool isGrounded;

    Animator animator;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Physics2D.queriesStartInColliders = false;

		animator.applyRootMotion = false;
    }

    void Update()
    {
        CheckIfGrounded();  
        HorizontalMovement();
        Jump();
    }

    private void HorizontalMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");

        xVelocity = x * maxSpeed;
        rb2D.velocity = new Vector2(xVelocity, rb2D.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(xVelocity)); 

        
        if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Facing left
        }
        else if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Facing right
        }
    }

    private void Jump()
    {

        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpPower);
        }

        
        if (Input.GetButtonUp("Jump") && rb2D.velocity.y > 0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.5f);
        }
    }

    private void CheckIfGrounded()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

    }
}