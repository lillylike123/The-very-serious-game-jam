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
    public float jumpForce = 10f;
    public float flappyForce = 8f;

    [Header("Ground Check")]
    public float groundCheckRadius = 0.25f;

    [Header("Coyote Time")]
    public float coyoteTime = 0.15f;

    private float coyoteCounter;
    private bool isGrounded;

    void Update()
    {
        CheckGround();

        if (isGrounded)
        {
            coyoteCounter = coyoteTime;
        }
        else
        {
            coyoteCounter -= Time.deltaTime;
        }

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

    void HandleJump()
    {
        // FLAPPY MODE
        if (chaosManager != null &&
            chaosManager.IsFlappyMode())
        {
            HandleFlappyMode();
            return;
        }

        // NORMAL MODE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (coyoteCounter > 0)
            {
                if (chaosManager != null)
                {
                    chaosManager.HandleJumpChaos();
                }

                Vector2 jumpDirection =
                    rb.gravityScale > 0
                    ? Vector2.up
                    : Vector2.down;

                rb.linearVelocity = new Vector2(
                    rb.linearVelocity.x,
                    0f
                );

                rb.AddForce(
                    jumpDirection * jumpForce,
                    ForceMode2D.Impulse
                );

                coyoteCounter = 0;
            }
        }
    }

    void HandleFlappyMode()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 flapDirection =
                rb.gravityScale > 0
                ? Vector2.up
                : Vector2.down;

            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                0f
            );

            rb.AddForce(
                flapDirection * flappyForce,
                ForceMode2D.Impulse
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
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
