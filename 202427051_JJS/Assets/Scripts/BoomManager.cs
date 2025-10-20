using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BoomManager : MonoBehaviour
{
    public GameObject buttonObject;    // ��ư GameObject (UI Button ����)
    public GameObject prefabToSpawn;   // ������ ������
    public float spawnInterval = 0.5f; // ���� ����
    public float initialDelay = 1f;    // ��ư Ŭ�� �� ���� ����

    private bool spawning = false;

    public void OnButtonClick()
    {
        // 1. ��ư ��Ȱ��ȭ
        buttonObject.SetActive(false);

        // 2. ���� ����
        if (!spawning)
        {
            spawning = true;
            StartCoroutine(SpawnPrefabLoop());
        }
    }

    private IEnumerator SpawnPrefabLoop()
    {
        // �ʱ� ���
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
