using TMPro;
using UnityEngine;

public class CarrotMove : MonoBehaviour
{
    public float carrotSpeed;
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.left * carrotSpeed * Time.deltaTime);

        if (transform.position.x < -9) gameObject.SetActive(false);
    }

    public void CarrotInit()
    {
        transform.position = new Vector2(9f, Random.Range(-2.2f, 2.2f));
    }
}