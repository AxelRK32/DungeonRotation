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
    SpriteRenderer sprite;

    Animator animator;
    public Transform groundCheck;
    public LayerMask groundLayer;

    // Reference to the onDeath script
    private Death deathScript;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Physics2D.queriesStartInColliders = false;
<<<<<<< Updated upstream
		animator.applyRootMotion = false;
=======

        // Initialize the deathScript
        deathScript = GetComponent<Death>();

        animator.applyRootMotion = false;
>>>>>>> Stashed changes
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
        if (Physics2D.gravity.y > 0 || Physics2D.gravity.x < 0)
            x *= -1;

        xVelocity = x * maxSpeed;
        if (Physics2D.gravity.x != 0)
            rb2D.velocity = new Vector2(rb2D.velocity.x, xVelocity);
        else
            rb2D.velocity = new Vector2(xVelocity, rb2D.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(xVelocity)); 

<<<<<<< Updated upstream
        
        if ((x < 0 && Physics2D.gravity.y < 0) || (x > 0 && Physics2D.gravity.y > 0) || (x > 0 && Physics2D.gravity.x < 0) || (x < 0 && Physics2D.gravity.x > 0))
=======
        if (x < 0)
>>>>>>> Stashed changes
        {
            //transform.localScale = new Vector3(-1, 1, 1); // Facing left
            sprite.flipX = true;
        }
        else if ((x > 0 && Physics2D.gravity.y < 0) || (x < 0 && Physics2D.gravity.y > 0) || (x < 0 && Physics2D.gravity.x < 0) || (x > 0 && Physics2D.gravity.x > 0))
        {
            //transform.localScale = new Vector3(1, 1, 1); // Facing right
            sprite.flipX = false;
        }
    }

    private void Jump()
    {
<<<<<<< Updated upstream

        
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
=======
        if (Input.GetButtonDown("Jump") && isGrounded)
>>>>>>> Stashed changes
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpPower);
        }

<<<<<<< Updated upstream
        
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && rb2D.velocity.y > 0)
=======
        if (Input.GetButtonUp("Jump") && rb2D.velocity.y > 0)
>>>>>>> Stashed changes
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.5f);
        }
    }

    private void CheckIfGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    public void DieSoon(float time)
    {
        if (deathScript != null)
        {
            Invoke("TriggerDeath", time);
        }
    }

    private void TriggerDeath()
    {
        deathScript.Dead();
    }
}