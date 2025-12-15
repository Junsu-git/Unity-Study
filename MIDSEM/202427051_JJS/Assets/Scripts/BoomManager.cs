using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BoomManager : MonoBehaviour
{
    public GameObject buttonObject;    // 버튼 GameObject (UI Button 포함)
    public GameObject prefabToSpawn;   // 생성할 프리팹
    public float spawnInterval = 0.5f; // 생성 간격
    public float initialDelay = 1f;    // 버튼 클릭 후 시작 지연

    private bool spawning = false;

    public void OnButtonClick()
    {
        // 1. 버튼 비활성화
        buttonObject.SetActive(false);

        // 2. 스폰 시작
        if (!spawning)
        {
            spawning = true;
            StartCoroutine(SpawnPrefabLoop());
        }
    }

    private IEnumerator SpawnPrefabLoop()
    {
        // 초기 대기
        yield return new WaitForSeconds(initialDelay);

        while (true)
        {
            SpawnPrefab();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnPrefab()
    {
        float x = Random.Range(-2f, 2f);
        float y = Random.Range(-2f, 2f);
        float z = 0f;

        Vector3 spawnPosition = new Vector3(x, y, z);
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}
