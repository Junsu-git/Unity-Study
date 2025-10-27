using TMPro;
using UnityEngine;

public class AniMove : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public float speed;
    int count;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(count >= 5)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            tmp.SetText("Go!!!!");
        }
        else
        {
            tmp.SetText("Count : " + count);
        }
    }

    public void Count()
    {
        count++;
    }
}
