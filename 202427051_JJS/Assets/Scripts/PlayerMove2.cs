using UnityEngine;

public class PlayerMove2 : MonoBehaviour
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
        
    }
    public void RunBtnClicked()
    {
        ani.SetTrigger("Run");
    }
    public void IdleBtnClicked()
    {
        ani.SetTrigger("Idle");
    }
}
