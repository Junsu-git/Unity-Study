using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class prollogue : MonoBehaviour
{
    public GameObject[] imgs;
    private SpriteRenderer[] sr;
    private float time = 0f;
    private int idx = 0;

    void Start()
    {
        // Initialize the SpriteRenderer array with the same length as imgs
        sr = new SpriteRenderer[imgs.Length];

        // Deactivate all images and store their SpriteRenderers
        for (int i = 0; i < imgs.Length; i++)
        {
            imgs[i].SetActive(false);
            sr[i] = imgs[i].GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {
        time += Time.deltaTime;

        // Every 2 seconds, show next image
        if (time >= 2.0f && idx < sr.Length)
        {
            time = 0;
            ShowImgs(idx++);
        }
    }

    private void ShowImgs(int index)
    {
        sr[index].gameObject.SetActive(true);
        StartCoroutine(FadeIn(sr[index], 1f));
    }

    // Coroutine for smooth fade-out
    private IEnumerator FadeIn(SpriteRenderer sprite, float duration)
    {
        Color color = sprite.color;
        float startAlpha = 0f;
        float targetAlpha = 1f;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            color.a = Mathf.Lerp(startAlpha, targetAlpha, t / duration);
            sprite.color = color;
            yield return null;
        }

        // Ensure it's fully visible at the end
        color.a = targetAlpha;
        sprite.color = color;
    }

    public void QBtnClicked()
    {
        SceneManager.LoadScene("MainScene");
    }
}
