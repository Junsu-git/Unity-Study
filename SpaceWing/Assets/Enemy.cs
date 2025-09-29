using UnityEngine;

public class Enemy : MonoBehaviour
{
    float enemySpeed;

    public enemyType currentType;
    public enum enemyType { Star, Purple, PurpleBullet, Uma }
    float RandomValue(float max, float min)
    {
        float value = Random.Range(max, min);
        return value;
    }

    private void OnEnable()
    {
        enemySpeed = RandomValue(3, 5);
    }
    void Star()
    {
        transform.Translate(Vector2.down * enemySpeed * Time.deltaTime);
    }

    void Purple()
    {

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

         //case enemyType.PurpleBullet:
         //    break;
         //case enemyType.Uma: break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}
