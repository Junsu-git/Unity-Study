using Unity.VisualScripting;
using UnityEngine;

public class AnimalMove : MonoBehaviour
{
    Animator ani;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        if(Mathf.Abs(v) >= 0.1 || Mathf.Abs(h) >= 0.1)
        {
            ani.SetBool("Move", true);
        }
        else
        {
            ani.SetBool("Move", false);
        }

        transform.Translate(new Vector2(h, v) * 5 * Time.deltaTime);
    }
}
