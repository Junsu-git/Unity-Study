using UnityEngine;

public class BgScroll : MonoBehaviour
{
    public float scrollSpeed;
    float targetOffset;
    Renderer rd;
    void Start()
    {
        rd = GetComponent<Renderer>();
    }

    void Update()
    {
        targetOffset += Time.deltaTime * scrollSpeed;
        rd.material.mainTextureOffset = new Vector2(targetOffset, 0);
    }
}
