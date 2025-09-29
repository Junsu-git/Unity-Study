using System.Security.Cryptography;
using UnityEngine;

public class UnderBackGround : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= -10.0f) gameObject.SetActive(false);
        transform.Translate(Vector2.down * 0.5f * Time.deltaTime);
    }
}
