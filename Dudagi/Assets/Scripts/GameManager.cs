using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Ready,
        Play,
        End
    }
    public int score;
    public float limitTime;
    public GameState gs;
    public AudioClip readySounds;
    public AudioClip goSound;
    public TextMeshProUGUI timetext;
    public TextMeshProUGUI ScoreText;

    public GameObject black;
    Image blackImg;

    public GameObject gameoverWindow;

    public TextMeshProUGUI recentScore;
    public TextMeshProUGUI highScore;

    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlaySound(readySounds);
        blackImg = black.GetComponent<Image>();
    }

    void GameOver()
    {
        limitTime = 0;
        blackImg.DOFade(0.8f, 0.5f);
        gs = GameState.End;
        RectTransform rectT = gameoverWindow.GetComponent<RectTransform>();
        rectT.DOAnchorPosY(0, 0.5f).SetDelay(0.5f);

        if (score > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
        recentScore.text = score.ToString();
        highScore.text = PlayerPrefs.GetInt("BestScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(gs == GameState.Play)
        {
            limitTime -= Time.deltaTime;
            if (limitTime <= 0)
            {

                GameOver();
            }
            timetext.text = limitTime.ToString("N2");
            ScoreText.text = score.ToString();
        }
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip; 
        audioSource.Play();
    }

    public void Go()
    {
        gs = GameState.Play;
        PlaySound(goSound);
    }
}
