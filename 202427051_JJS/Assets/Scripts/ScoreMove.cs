using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreMove : MonoBehaviour
{
    Animator ani;
    bool isUp = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnClicked()
    {
        if (isUp)
        {
            isUp = false;
            ani.SetTrigger("MoveUp");
        }
        else
        {
            isUp = true;
            ani.SetTrigger("MoveDown");
        }
    }

}
