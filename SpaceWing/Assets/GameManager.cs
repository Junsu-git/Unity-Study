using UnityEngine;

public class GameManager : MonoBehaviour
{
    float gameTime;
    public static GameManager instance;
    public PoolManager pool;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        Debug.Log(gameTime);
        if (gameTime >= 1f)
        {
            GameObject enemyStar = pool.Get(0);
            enemyStar.transform.position = new Vector2(Random.Range(-2.8f, 2.8f), 5.5f);
            gameTime = 0;
        }
    }
}
