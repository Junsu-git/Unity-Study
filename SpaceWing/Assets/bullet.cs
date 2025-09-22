using UnityEngine;

public class bullet : MonoBehaviour
{
    public float shotSpeed = 6.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up *  shotSpeed * Time.deltaTime);
    }
}
