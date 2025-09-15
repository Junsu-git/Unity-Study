using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Ready,
        Play,
        End
    }
    public int score;
    float limitTime;
    public GameState gs;
    public AudioClip readySounds;
    public AudioClip goSound;
    public TextMeshProUGUI timetext;
    public TextMeshProUGUI ScoreText;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlaySound(readySounds);
    }

    // Update is called once per frame
    void Update()
    {
        if(gs == GameState.Play)
        {
            limitTime -= Time.deltaTime;
            if (limitTime <= 0) limitTime = 0;
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
