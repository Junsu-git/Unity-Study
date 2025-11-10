using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RocketController : MonoBehaviour
{
    [Header("Movement Settings")]
    float moveSpeed = 4f;         // 기본 이동 속도
    float rotationSpeed = 200f;   // 회전 속도
    float macceleration = 0.2f;      // 속도 변화 부드럽게
    float sacceleration = 1f;      // 속도 변화 부드럽게

    [Header("Animation Settings")]
    Animator animator;            // 로켓 Animator 연결

    private Rigidbody2D rb;
    private float currentSpeed = 0f;
    private bool isMove = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleRotation();
        HandleMovement();
        UpdateAnimationParameters();
        Debug.Log(currentSpeed);
    }

    private void HandleRotation()
    {
        float rotateInput = Input.GetAxisRaw("Horizontal"); // A/D
        transform.Rotate(0, 0, -rotateInput * rotationSpeed * Time.deltaTime);
    }

    private void HandleMovement()
    {
        float moveInput = Input.GetAxisRaw("Vertical"); // W/S
        float targetSpeed = moveInput * moveSpeed;

        // 부드러운 가속 / 감속
        if(moveInput >=  0.1f)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, macceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, sacceleration * Time.deltaTime);
        }

            // 앞 방향으로 이동
            rb.linearVelocity = transform.up * currentSpeed;

        // 움직임 여부 판단
        isMove = moveInput >= 0.1;
    }

    private void UpdateAnimationParameters()
    {
        // Animator 파라미터 전달
        animator.SetBool("isMove", isMove);
        animator.SetFloat("speed", Mathf.Abs(currentSpeed)); // 절대값으로 전달 (후진 시에도 양수)
    }
}
