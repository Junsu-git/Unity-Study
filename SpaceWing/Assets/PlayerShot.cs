using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject bulletStorage;
    public int pollSize = 10; // 총알 수
    GameObject[] bulletObjectPoll; // 오브젝트 풀 배열
    public GameObject pos;
    float shotTime;
    void Start()
    {
        // 탄창을 총알 담을 수 있는 크기로 생성
        bulletObjectPoll = new GameObject[pollSize];

        for(int i = 0; i< pollSize; i++)
        {
            // 총알생성
            GameObject bullet = Instantiate(bulletStorage);
            bulletObjectPoll[i] = bullet;
            bullet.SetActive(false);
        }
    }

    void Update()
    {
        shotTime += Time.deltaTime;
        if (Input.GetMouseButton(0) && shotTime >= 0.2f)
        {
            for (int i = 0; i < pollSize; i++) 
            {
                GameObject bullet = bulletObjectPoll[i];
                if(bullet.activeSelf == false) 
                { 
                    bullet.SetActive(true);
                    bullet.transform.position = pos.transform.position;

                    shotTime = 0;
                    break;
                }
            }
        }
    }
}
