using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float scrollSpeed;
    float targetOffset;
    Renderer backRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        backRenderer = GetComponent<Renderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        targetOffset += Time.deltaTime * scrollSpeed;
        backRenderer.material.mainTextureOffset = new Vector2(0, targetOffset);
    }
}
