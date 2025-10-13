
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float enemySpeed;
    float stopY;
    bool isStop;
    float randomZ;
    float shotTime;
    public enemyType currentType;
    float umaMoveX;
    bool isGoLEft; // 왼쪽으로 가느냐
    public enum enemyType { Star, Purple, Uma, PurpleBullet }
    float RandomValue(float min, float max)
    {
        float value = Random.Range(min, max);
        return value;
    }

    private void OnEnable()
    {
        enemySpeed = RandomValue(3, 5);
        stopY = RandomValue(0, 4);
        isStop = false;
        randomZ = RandomValue(-90, 90);
        shotTime = 0;
        if (RandomValue(0, 1) > 0.5)
        {
            umaMoveX = -6f;
            isGoLEft = true;
        }
        else
        {
            umaMoveX = 6f;
            isGoLEft = false;
        }
    }
    void Star()
    {
        transform.Translate(Vector2.down * enemySpeed * Time.deltaTime);
    }

    void Purple()
    {
        // 퍼플은 랜덤 스피드를 가지고 있음. enemy speed 가 동일한 역할을 해줌
        // y값 0~4사이 랜덤하게 멈춤
        if (transform.position.y < stopY)
        {
            enemySpeed = 0;
            isStop = true;
        }
        transform.Translate(Vector2.down * enemySpeed * Time.deltaTime);
        if (isStop)
        {
            shotTime += Time.deltaTime;
            if (shotTime >= 1)
            {
                ShotBullet();
            }
        }
    }

    private void ShotBullet()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y +0.8f);
        GameObject purpleBullet = GameManager.instance.pool.Get(3);
        purpleBullet.transform.position = pos;
        purpleBullet.transform.rotation = Quaternion.Euler(new Vector3(Mathf.Sin(30 * Time.deltaTime * 4), Mathf.Cos(30 * Time.deltaTime * 4), randomZ));
        shotTime = 0;
    }
    private void Uma()
    {
        transform.Translate(Vector2.down * enemySpeed * Time.deltaTime);
        transform.Translate(Vector2.right * umaMoveX * Time.deltaTime);
        if (transform.position.x > 3f)
        {
            isGoLEft = false;
            umaMoveX *= -1;
        }
        else if (transform.position.x < -3f)
        {
                isGoLEft = true;
                umaMoveX *= -1;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentType)
        {
            case enemyType.Star:
                Star();
                break;
            case enemyType.Purple:
                Purple();
                break;
            case enemyType.Uma:
                //Debug.Log(currentType);
                Uma();
                break;
         //case enemyType.PurpleBullet:
         //    break;
         //case enemyType.Uma: break;
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("back")) gameObject.SetActive(false);
    }
}
