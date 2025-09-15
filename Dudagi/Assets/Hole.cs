using System.Collections;
using UnityEngine;

public class Hole : MonoBehaviour
{
    Animator ani;
    bool isTouch = false;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void Open()
    {
        isTouch = true;
    }
    public void Close()
    {
        isTouch = false;
    }

    private void OnMouseDown()
    {
        if (isTouch)
        {
            isTouch = false;
            ani.SetTrigger("isTouch");
        }
    }

    public IEnumerator End()
    {
        float randomTime = Random.Range(1.0f, 3.0f);
        yield return new WaitForSeconds(randomTime);

        ani.SetTrigger("DOpen");
    }

    void Update()
    {
        
    }
}
