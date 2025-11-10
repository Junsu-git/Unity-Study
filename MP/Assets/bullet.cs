using UnityEngine;

public class bullet : MonoBehaviour
{
    float speed = 10f;
    private float lifetime = 3f; // 일정 시간 후 비활성화용

    void OnEnable()
    {
        // 일정 시간 뒤 비활성화 (풀로 복귀)
        Invoke(nameof(Deactivate), lifetime);
    }

    void OnDisable()
    {
        // 다시 활성화될 때 Invoke 중복 방지
        CancelInvoke();
    }

    void Update()
    {
        // 자신의 앞 방향으로 이동
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
