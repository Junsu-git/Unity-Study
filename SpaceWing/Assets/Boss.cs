using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameObject[] bossBullets;
    public Image bossHp;
    bool bossMove;
    bool bossFire;
    public int bossLife;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossMove = true;
        bossFire = false;
        bossLife = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossMove)
        {
            transform.Translate(Vector2.down * 2.0f * Time.deltaTime);
            if(transform.position.y < 2)
            {
                bossMove=false;
                bossFire = true;
            }
        }
        if (bossFire)
        {
            StartCoroutine(Bullets());
            bossFire = false;
        }
    }

    IEnumerator Bullets()
    {
        while(true)
        {
            foreach(GameObject go in bossBullets)
            {
                if(go != null)
                {
                    go.transform.position = transform.position;
                    go.SetActive(true);
                }
            }
            yield return new WaitForSeconds(2.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!bossMove)
        {
            if (collision.CompareTag("PlayerBullet"))
            {
                collision.gameObject.SetActive(false);
                bossLife--;
                bossHp.fillAmount -= 0.02f;
            }
        }
    }
}