using UnityEngine;

public class AnimalChange : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ani.SetTrigger("Ani1");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ani.SetTrigger("Ani3");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ani.SetTrigger("Ani4");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ani.SetTrigger("Ani2");
        }
    }
}
