using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    private Vector2 initMousePos;
    private Vector2 diffPos;
    private Vector2 cursorPos;
    int playerHp;
    public Image playerLife;

    private void OnMouseDown()
    {
        initMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        diffPos = cursorPos - initMousePos;
        initMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        player.transform.position =
            new Vector2(Mathf.Clamp(player.transform.position.x + diffPos.x, -2.5f, 2.5f),
            Mathf.Clamp(player.transform.position.y + diffPos.y, -4.5f, 4.5f));
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(playerHp <= 1)
        {
            // °ÔÀÓ ³¡
        }
        else
        {
            playerHp -= 1;
            playerLife.fillAmount -= 0.34f;
            GameObject boom = GameManager.instance.pool.Get(4);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
