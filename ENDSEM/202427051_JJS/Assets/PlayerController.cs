using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public int maxJumpCount = 2; // 최대 점프 횟수 (2단 점프)

    [Header("Components")]
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private int currentJumpCount = 0; // 현재 점프한 횟수
    private bool isGrounded = false;
    private bool isDead = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!GameManager.Instance.IsGameActive || isDead) return;

        HandleMovement();
        HandleJump();
        UpdateAnimationState();
    }

    private void HandleMovement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * h * moveSpeed * Time.deltaTime);

        if (h != 0)
        {
            spriteRenderer.flipX = (h < 0);
        }
    }

    private void HandleJump()
    {
        // 스페이스바를 눌렀을 때 && (땅에 있거나 OR 점프 횟수가 남아있으면)
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || currentJumpCount < maxJumpCount))
        {
            Jump();
        }
    }

    private void Jump()
    {
        // [핵심] 더블 점프 시, 기존에 떨어지던 속도를 없애야 위로 솟구침
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        // 상태 업데이트
        isGrounded = false;
        currentJumpCount++; // 점프 횟수 증가

        // 애니메이션 (이미 점프 중이어도 트리거를 다시 때려서 반응하게 함)
        anim.SetTrigger("doJump");
    }

    private void UpdateAnimationState()
    {
        float h = Input.GetAxisRaw("Horizontal");
        bool isRunning = (h != 0);

        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isGrounded", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 바닥 착지
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            currentJumpCount = 0; // [중요] 점프 횟수 초기화
        }

        // 장애물 충돌
        if (collision.gameObject.GetComponent<EnvironmentObject>() != null)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<EnvironmentObject>() != null)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        anim.SetTrigger("doDie");
        rb.linearVelocity = Vector2.zero;
        GameManager.Instance.GameOver();
    }
}