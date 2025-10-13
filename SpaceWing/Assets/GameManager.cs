using UnityEngine;

public class GameManager : MonoBehaviour
{
    float gameTime;
    public static GameManager instance;
    public PoolManager pool;

    public int enemyNum;
    private int enemySpawnCount = 0;

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
        //Debug.Log(gameTime);
        if (gameTime >= 1f)
        {
            EnemySpawn(0);
            if (enemySpawnCount > 5) EnemySpawn(2);
            if (enemySpawnCount > 10) EnemySpawn(1);
            enemySpawnCount++;
            gameTime = 0;
        }
    }

    void EnemySpawn(int enemyGet)
    {
        GameObject enemy = pool.Get(enemyGet);
        enemy.transform.position = new Vector2(Random.Range(-2.8f, 2.8f), 5.5f);
    }
}
