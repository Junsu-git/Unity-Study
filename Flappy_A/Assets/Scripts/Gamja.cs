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
        if(other.CompareTag("Die") && !gm.end)
        {
            rb.linearVelocity = new Vector3(0, -10, 0);
            lookDir = new Vector3(0, 0, -180);
            //rb.isKinematic = true;
            gm.GameOver();
        } 

        if(other.CompareTag("Goal"))
        {
            gm.GetScore();
        }
    }
}
