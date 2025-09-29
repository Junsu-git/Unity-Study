using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float scrollSpeed;
    float targetOffset;
    Renderer backRenderer;
    
    void Start()
    {
        backRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        targetOffset += Time.deltaTime * scrollSpeed;
        backRenderer.material.mainTextureOffset
            = new Vector2(0, targetOffset);
    }

}
