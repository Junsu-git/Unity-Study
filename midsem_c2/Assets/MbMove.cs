using UnityEngine;

public class MbMove : MonoBehaviour
{
    Animator ani;
    public GameObject bg;
    public GameObject btn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ani = GetComponent<Animator>();
        bg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Begin()
    {
        ani.SetBool("Turn", true);
        bg.SetActive(true);
    }

    public void BtnClick()
    {
        btn.SetActive(false);
        ani.SetTrigger("Click");
    }
}
