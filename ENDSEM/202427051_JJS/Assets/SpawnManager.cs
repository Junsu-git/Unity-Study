using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    [Header("Spawn Settings")]
    public float xBound = 9.5f;     // 화면 좌우 끝 좌표
    public float topSpawnY = 6.0f;  // 위에서 생성될 때 Y좌표 (고정)
    public float sideSpawnY = -3.0f;// [수정됨] 옆에서 생성될 때 Y좌표 (고정 -3)

    // public float yRange = 4.0f;  // <-- 랜덤 범위는 더 이상 사용하지 않으므로 삭제

    private void Awake()
    {
        Instance = this;
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(1.5f);

        while (GameManager.Instance.IsGameActive)
        {
            SpawnObject();
            yield return new WaitForSeconds(1.0f);
        }
    }

    private void SpawnObject()
    {
        // 1. 랜덤 타입 결정
        string type = (Random.Range(0, 2) == 0) ? "Grass" : "Rock";
        GameObject obj = PoolingManager.Instance.GetFromPool(type);
        EnvironmentObject envScript = obj.GetComponent<EnvironmentObject>();

        // 2. 생성 위치 결정
        int spawnSide = Random.Range(0, 3); // 0: 위, 1: 왼쪽, 2: 오른쪽

        Vector3 spawnPos = Vector3.zero;
        Vector3 direction = Vector3.zero;
        bool isFromTop = false;

        switch (spawnSide)
        {
            case 0: // 위에서 생성
                // X값 랜덤, Y값 고정(topSpawnY)
                spawnPos = new Vector3(Random.Range(-xBound, xBound), topSpawnY, 0);
                direction = Vector3.down;
                isFromTop = true;
                break;

            case 1: // 왼쪽에서 생성
                // X값 고정(왼쪽 끝), Y값 고정(sideSpawnY -> -3)
                spawnPos = new Vector3(-xBound, sideSpawnY, 0);
                direction = Vector3.right;
                isFromTop = false;
                break;

            case 2: // 오른쪽에서 생성
                // X값 고정(오른쪽 끝), Y값 고정(sideSpawnY -> -3)
                spawnPos = new Vector3(xBound, sideSpawnY, 0);
                direction = Vector3.left;
                isFromTop = false;
                break;
        }

        // 3. 초기화 (레이어 설정은 EnvironmentObject의 Awake에서 처리됨)
        if (envScript != null)
        {
            envScript.Initialize(direction, spawnPos, isFromTop);
        }
    }
}