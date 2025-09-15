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

    public GameState gs;
    public AudioClip readySounds;
    public AudioClip goSound;
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
