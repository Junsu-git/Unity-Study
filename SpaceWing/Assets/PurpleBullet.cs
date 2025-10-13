using UnityEngine;

public class PurpleBullet : MonoBehaviour
{
    float bulletSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        bulletSpeed = 4f;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.down * bulletSpeed * Time.deltaTime);
    }
}
