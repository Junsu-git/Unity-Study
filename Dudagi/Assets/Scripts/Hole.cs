using System.Collections;
using UnityEngine;

public class Hole : MonoBehaviour
{
    Animator ani;
    AudioSource audioSource;
    bool isTouch = false;

    public AudioClip openSound;
    public AudioClip closeSound;
    public AudioClip catchSound;
    public AudioClip bombSound;
    public GameManager gm;
    private bool isBomb;

    void Start()
    {
        ani = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
    public void Open()
    {
        isTouch = true;
        PlaySound(openSound);
        if (gm.gs == GameManager.GameState.Ready)
        {
            gm.Go();
        }
    }
    public void Close()
    {
        isTouch = false;
    }

    private void OnMouseDown()
    {
        if (isTouch)
        {
            isTouch = false;
            ani.SetTrigger("isTouch");
            if (isBomb)
            {
                gm.score--;
                PlaySound(bombSound);
            }
            else
            {
                gm.score++;
                PlaySound(catchSound);
            }
        }
    }

    public IEnumerator End()
    {
        float randomTime = Random.Range(1.0f, 3.0f);
        float randomD = Random.Range(1.0f, 10.0f);
        yield return new WaitForSeconds(randomTime);

        if (gm.gs != GameManager.GameState.End)
        {
            if (randomD >= 2.0f)
            {
                ani.SetTrigger("BOpen");
                isBomb = true;
            }
            else
            {
                ani.SetTrigger("DOpen");
                isBomb = false;
            }
        }
    }

    void Update()
    {

    }
}
