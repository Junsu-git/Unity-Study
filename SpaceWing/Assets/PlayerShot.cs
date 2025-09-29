using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject bulletStorage;
    public int pollSize = 10; // �Ѿ� ��
    GameObject[] bulletObjectPoll; // ������Ʈ Ǯ �迭
    public GameObject pos;
    float shotTime;
    void Start()
    {
        // źâ�� �Ѿ� ���� �� �ִ� ũ��� ����
        bulletObjectPoll = new GameObject[pollSize];

        for(int i = 0; i< pollSize; i++)
        {
            // �Ѿ˻���
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
