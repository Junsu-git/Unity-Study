using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager Instance;

    [Header("Prefabs")]
    public GameObject grassPrefab;
    public GameObject rockPrefab;

    [Header("Settings")]
    public int poolSize = 10;

    // 오브젝트별 큐 관리 (Key: 태그 혹은 이름)
    private Queue<GameObject> grassPool = new Queue<GameObject>();
    private Queue<GameObject> rockPool = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;
        InitializePool(grassPrefab, grassPool);
        InitializePool(rockPrefab, rockPool);
    }

    private void InitializePool(GameObject prefab, Queue<GameObject> pool)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            obj.transform.SetParent(this.transform); // 정리용
            pool.Enqueue(obj);
        }
    }

    public GameObject GetFromPool(string type)
    {
        Queue<GameObject> targetPool = (type == "Grass") ? grassPool : rockPool;
        GameObject prefab = (type == "Grass") ? grassPrefab : rockPrefab;

        if (targetPool.Count > 0)
        {
            GameObject obj = targetPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            // 풀이 모자라면 새로 생성
            GameObject obj = Instantiate(prefab);
            obj.transform.SetParent(this.transform);
            return obj;
        }
    }

    public void ReturnToPool(GameObject obj, string type)
    {
        obj.SetActive(false);
        if (type == "Grass") grassPool.Enqueue(obj);
        else rockPool.Enqueue(obj);
    }
}