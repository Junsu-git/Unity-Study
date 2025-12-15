using UnityEngine;

public class BoomRemove : MonoBehaviour
{
    float t = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if(t > 0.7)
            Destroy(gameObject);
    }
}
