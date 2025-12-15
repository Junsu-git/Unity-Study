using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro; // [필수] 씬 로드 기능을 위해 추가

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI References")]
    public Image startImage;
    public GameObject startPanel;
    public GameObject gameOverPanel; // [추가] 게임 오버 패널 참조
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

    [Header("Game State")]
    public bool IsGameActive { get; private set; } = false;

    private float currentScore = 0f;
    private float bestScore = 0f;

    public const int LAYER_ENV = 6;
    public const int LAYER_GROUND = 7;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        // 게임 시작 시에는 게임 오버 패널을 확실하게 꺼둡니다.
        if (gameOverPanel != null) gameOverPanel.SetActive(false);

        bestScore = PlayerPrefs.GetFloat("BestScore", 0f);
        UpdateScoreUI();

        StartCoroutine(BlinkStartText());
        SetupPhysicsLayers();
    }

    private void Update()
    {
        if (!IsGameActive && Input.anyKeyDown && startPanel.activeSelf)
        {
            StartGame();
        }

        if (IsGameActive)
        {
            currentScore += Time.deltaTime;
            if (currentScore > bestScore)
            {
                bestScore = currentScore;
            }
            UpdateScoreUI();
        }
    }

    private void StartGame()
    {
        IsGameActive = true;
        currentScore = 0f;

        StopAllCoroutines();
        startPanel.SetActive(false);
        startImage.gameObject.SetActive(false);

        SpawnManager.Instance.StartSpawning();
    }

    public void GameOver()
    {
        IsGameActive = false;

        PlayerPrefs.SetFloat("BestScore", bestScore);
        PlayerPrefs.Save();

        // 1. 장애물 정리
        EnvironmentObject[] allObstacles = FindObjectsOfType<EnvironmentObject>();
        foreach (EnvironmentObject obj in allObstacles)
        {
            if (obj.gameObject.activeSelf)
            {
                PoolingManager.Instance.ReturnToPool(obj.gameObject, obj.objectType);
            }
        }

        // 2. [추가] 게임 오버 패널 활성화
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Debug.Log("Game Over!");
    }

    // [추가] 버튼 클릭 시 연결될 재시작 함수
    public void RetryGame()
    {
        // 현재 활성화된 씬의 이름을 가져와서 다시 로드 (초기화)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // (나머지 기존 함수들: UpdateScoreUI, BlinkStartText, SetupPhysicsLayers 등은 그대로 유지)
    private void UpdateScoreUI()
    {
        if (scoreText != null) scoreText.text = $"Time: {currentScore:F2}s";
        if (bestScoreText != null) bestScoreText.text = $"Best: {bestScore:F2}s";
    }

    IEnumerator BlinkStartText()
    {
        while (!IsGameActive)
        {
            startImage.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.5f);
            startImage.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SetupPhysicsLayers()
    {
        Physics2D.IgnoreLayerCollision(LAYER_ENV, LAYER_ENV, true);
        Physics2D.IgnoreLayerCollision(LAYER_ENV, LAYER_GROUND, false);
    }
}