using UnityEngine;

public class CarrotMove : MonoBehaviour
{
    public float carrotSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * carrotSpeed * Time.deltaTime);
        if (transform.position.x < -20) Destroy(gameObject);

    }

    private void OnEnable()
    {
        transform.position = new Vector2(20f, Random.Range(-2.2f, 2.2f));
    }
}
