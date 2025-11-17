using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float waitingTime = 1.5f;
    public bool ready = true;
    public GameObject carrot;
    public GameObject player;
    public bool end = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && ready == true)
        {
            ready = false;
            player.gameObject.GetComponent<Rigidbody2D>().simulated = true; 
            InvokeRepeating("MakeCarrot", 1f, waitingTime);
        }
    }

    public void GameOver()
    {
        end = true;
        CancelInvoke("MakeCarrot");
    }

    void MakeCarrot()
    {
        Instantiate(carrot);
    }
}
