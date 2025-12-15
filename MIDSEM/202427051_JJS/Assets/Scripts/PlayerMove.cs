using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    bool isGround = false;
    Animator ani;
    Rigidbody2D rb;
    SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        sr.flipX = h < 0;
        transform.Translate(Vector2.right * 5 * Time.deltaTime * h);

        if (Input.GetKeyDown((KeyCode.UpArrow)) && isGround)
        {
            ani.SetTrigger("Jump");
            rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
            isGround = false;
        }

        ani.SetBool("isRunning", Mathf.Abs(h) > 0);
        ani.SetBool("isGrounded", isGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }
}
