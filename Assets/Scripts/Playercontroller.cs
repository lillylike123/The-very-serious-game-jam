using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public ChaosEffectManager chaosManager;
    public GameManager gameManager;

    [Header("Jump")]
    public float jumpForce = 500f;

    [Header("Ground Check")]
    public float groundCheckRadius = 0.25f;

    [Header("Coyote Time")]
    public float coyoteTime = 0.15f;

    private float coyoteCounter;
    private bool isGrounded;

    void Update()
    {
        CheckGround();
        HandleCoyoteTime();
        HandleJump();
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );
    }

    void HandleCoyoteTime()
    {
        if (isGrounded)
        {
            coyoteCounter = coyoteTime;
        }
        else
        {
            coyoteCounter -= Time.deltaTime;
        }
    }

    void HandleJump()
{
    if (Input.GetKeyDown(KeyCode.Space) && coyoteCounter > 0)
    {
        chaosManager.HandleJumpChaos();

        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            0
        );

        if (rb.gravityScale > 0)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
        else
        {
            rb.AddForce(Vector2.down * jumpForce);
        }
    }
}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            gameManager.GameOver();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
            return;

        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(
            groundCheck.position,
            groundCheckRadius
        );
    }
}
