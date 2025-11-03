using UnityEngine;

public class BossBullet : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.down * 3.0f * Time.deltaTime);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("back")) gameObject.SetActive(false);
    }
}
