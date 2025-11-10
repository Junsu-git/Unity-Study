using UnityEngine;

public class PlayerBulletPool : MonoBehaviour
{
    public GameObject bulletStorage;
    public int poolSize = 10;
    GameObject[] bulletObjectPool;

    // 기존: public GameObject pos;
    // 수정: Transform으로 변경 (회전 정보도 사용하기 위함)
    public Transform pos;

    private float shotTime;

    void Start()
    {
        bulletObjectPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletStorage);
            bulletObjectPool[i] = bullet;
            bullet.SetActive(false);
        }
    }

    void Update()
    {
        shotTime += Time.deltaTime;

        // 기존: Fire 로직이 Update 내부에 직접 있었음
        // 수정: 별도 메서드로 분리 (가독성 및 재사용성 향상)
        if (Input.GetKey(KeyCode.Space) && shotTime >= 0.1f)
        {
            FireBullet();
            shotTime = 0;
        }
    }

    private void FireBullet()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = bulletObjectPool[i];
            if (!bullet.activeSelf)
            {
                // 기존:
                // bullet.SetActive(true);
                // bullet.transform.position = pos.transform.position;

                // 수정:
                bullet.transform.position = pos.position;     // 위치 설정 (Transform 직접 사용)
                bullet.transform.rotation = pos.rotation;     // 추가: 발사 방향 일치
                bullet.SetActive(true);
                break;
            }
        }
    }
}
