using NUnit.Framework.Constraints;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower = 20f;
    Rigidbody2D rb;
    public GameManager gm;
    bool death = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && transform.position.y < 5){
            rb.linearVelocity = new Vector2(0, 0);
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        Debug.Log(death);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Die"))
        {
            rb.linearVelocity = new Vector2(0, -3);
            gm.GameOver();
            death = true;
        }
        if (collision.collider.CompareTag("Goal"))
        {

        }
    }
    
}
