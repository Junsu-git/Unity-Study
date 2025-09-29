using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float shotSpeed = 6.0f;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector2.up * shotSpeed * Time.deltaTime);   
    }
}
