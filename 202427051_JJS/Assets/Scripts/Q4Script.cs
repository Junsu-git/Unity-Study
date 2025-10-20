using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Q4Script : MonoBehaviour
{
    bool isReady = false;
    public GameObject explosion;
    float t = 3;
    public TextMeshPro tmp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        explosion.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (!isReady) return;
        t -= Time.deltaTime;
        
        if(t < 0)
        {
            explosion.SetActive(true);
            gameObject.SetActive(false);
            tmp.SetText("BOOM!!!");
        }
        else
        {
            tmp.SetText("Time : " + t.ToString("F2"));
        }

    }
    public void OnMouseDown()
    {
        isReady = true;
    }
}
