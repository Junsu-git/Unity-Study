using UnityEngine;

public class BgScroll : MonoBehaviour
{
    public float scrollSpeed;
    float targetOffset;
    Renderer rd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rd = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        targetOffset += Time.deltaTime * scrollSpeed;
        rd.material.mainTextureOffset = new Vector2(targetOffset, 0);
    }
}
