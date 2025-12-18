using UnityEngine;

public class Gamja : MonoBehaviour
{
    public float jumpPower = 5f;
    public GameManager gm;
    Rigidbody rb;
    SphereCollider sc;
    private Vector3 lookDir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && transform.position.y < 5f && !gm.end)
        {
            rb.linearVelocity = new Vector3(0,0, 0);
            rb.AddForce(0, jumpPower,0 , ForceMode.VelocityChange);
        }

        Quaternion r = Quaternion.Euler(lookDir);
        transform.rotation = r;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gm.end) return; 
        if(other.CompareTag("Die") && !gm.end) // 게임 시작 : end = false | !end = true -> 한번 닿으면 END = TRUE - 부정 > FALSE
        {
            rb.linearVelocity = new Vector3(0, -10, 0);
            lookDir = new Vector3(0, 0, -180);
            gm.GameOver();
        } 

        if(other.CompareTag("Goal"))
        {
            gm.GetScore();
        }
    }
}
