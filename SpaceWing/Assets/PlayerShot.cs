using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerShot : MonoBehaviour
{
    public GameObject bulletStorage;
    public int pollSize = 10;
    GameObject[] bulletObjectPoll; // Array for Bullet Object Polling
    private float shotTime;
    public Transform pos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletObjectPoll = new GameObject[pollSize];

        for(int i = 0; i < pollSize; i++)
        {
            GameObject bullet = Instantiate(bulletStorage);
            bulletObjectPoll[i] = bullet;
            bullet.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        shotTime += Time.deltaTime;
        if (Input.GetMouseButton(0) && shotTime >= 0.2f)
        {
            for (int i = 0; i < pollSize; i++)
            {
                GameObject bullet = bulletObjectPoll[i];
                bullet.SetActive(true);
                bullet.transform.position = pos.transform.position;

                shotTime = 0;
                break;
            }
        }
    }
}
