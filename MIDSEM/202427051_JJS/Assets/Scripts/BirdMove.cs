using TMPro;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    int count = 0;
    bool isReady = false;
    public TextMeshPro tmp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tmp.SetText("Count : " + count.ToString());
        if (!isReady) return;
        if (transform.position.x < 5)
        {
            transform.Translate(Vector2.right * 3 * Time.deltaTime);
        }
    }

    public void AniCount()
    {
        if (isReady) return;
        count++;
        if(count == 5)
        {
            isReady = true;
        }
    }
}
