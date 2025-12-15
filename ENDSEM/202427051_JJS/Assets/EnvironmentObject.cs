using UnityEngine;

public class EnvironmentObject : MonoBehaviour
{
    public string objectType;
    public float speed = 5f;

    private Vector3 moveDirection;
    private bool isInitialized = false;
    private bool isFromTop = false;

    private Rigidbody2D rb;
    private Collider2D col;

    private void Awake()
    {
        // 컴포넌트 캐싱
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        // [레이어 설정] 
        // GameManager에서 정한 규칙(ENV끼리 무시, ENV-GROUND 충돌)을 따르기 위해 레이어 할당
        this.gameObject.layer = GameManager.LAYER_ENV;
    }

    public void Initialize(Vector3 direction, Vector3 startPos, bool fromTop)
    {
        transform.position = startPos;
        moveDirection = direction;
        isFromTop = fromTop;
        isInitialized = true;

        // [핵심 로직 분기]
        if (isFromTop)
        {
            // 1. 위에서 떨어지는 애들 (바닥에 닿으면 사라져야 함)
            // -> Trigger(유령) 모드 ON
            // -> 중력 0 (코드로 일정하게 내리꽂거나, 중력으로 내려도 Trigger라 뚫고 감)
            if (col != null) col.isTrigger = true;
            if (rb != null) rb.gravityScale = 0f;
        }
        else
        {
            // 2. 옆에서 나오는 애들 (바닥에 착지해서 이동해야 함)
            // -> Trigger 모드 OFF (실체화 -> 바닥 밟기 가능)
            // -> 중력 1 (바닥까지 뚝 떨어져야 함)
            if (col != null) col.isTrigger = false;
            if (rb != null) rb.gravityScale = 1f;

            // 회전 방지 (착지하다 구르지 않게)
            if (rb != null) rb.freezeRotation = true;
        }
    }

    private void Update()
    {
        if (!isInitialized) return;

        // [이동 로직]
        // 옆에서 나온 애들은 중력으로 Y축이 제어되므로, X축 이동만 적용됨 (Translate는 로컬/월드 기준에 따라 동작)
        // 위에서 나온 애들은 direction이 Vector3.down이라 아래로 내려감
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        // 화면 밖 처리 (옆으로 이동하는 애들)
        if (!isFromTop && IsOutOfBounds())
        {
            PoolingManager.Instance.ReturnToPool(this.gameObject, objectType);
        }
    }

    // [Trigger 충돌]: 위에서 떨어진 애들(Trigger 상태)이 바닥 감지
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isFromTop && other.gameObject.layer == GameManager.LAYER_GROUND)
        {
            PoolingManager.Instance.ReturnToPool(this.gameObject, objectType);
        }
    }

    // [Collision 충돌]: 옆에서 나온 애들(Non-Trigger)이 바닥에 닿았을 때
    // GameManager의 IgnoreLayerCollision 설정 덕분에 풀/바위끼리는 이 함수가 호출 안 됨.
    // 오직 바닥(Ground)하고만 부딪힘.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 옆에서 나온 애들은 바닥에 닿아도 사라지면 안 됨.
        // 그냥 물리적으로 착지(Land)하는 것이므로 아무 코드도 안 적어도 됨.
        // (물리 엔진이 알아서 멈춰 세움)
    }

    private bool IsOutOfBounds()
    {
        // 맵 끝 좌표 설정
        if (Mathf.Abs(transform.position.x) > 12f) return true;
        return false;
    }
}