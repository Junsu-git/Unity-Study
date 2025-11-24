using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public float waitingTime = 1.5f;
    public bool ready = true;
    public bool end = false;
    public GameObject carrot;
    public GameObject gamja;
    int score;
    public TextMesh scoreText;
    public GameObject readyImg;
    public GameObject gameOverImg;
    public GameObject scoreBoard;
    public GameObject newImg;
    public TextMesh playScoreText;
    public TextMesh bestScoreText;


    void Start()
    {
    }

    public void GetScore()
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && ready == true)
        {
            ready = false;
            gamja.GetComponent<Rigidbody>().useGravity = true;
            //InvokeRepeating("MakeCarrot", 1f, waitingTime); > 캐럿 생성 잠금
            iTween.FadeTo(readyImg, iTween.Hash("alpha", 0, "time", 0.5f));
        }
    }

    public void GameOver()
    {
        end = true;
        scoreText.gameObject.SetActive(false);
        //CancelInvoke("MakeCarrot");   >> 캐럿 취소 잠금
        iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("x", 0.2, "y", 0.2, "time", 0.5f));
        iTween.FadeTo(gameOverImg, iTween.Hash("alpha", 255, "delay", 1f, "time", 0.5f));
        iTween.MoveTo(scoreBoard, iTween.Hash("y", 0, "delay", 1.5, "time", 0.5f));
        if (score > PlayerPrefs.GetInt("BestScore", score))
        {
            PlayerPrefs.SetInt("BestScore", score);
            newImg.SetActive(true);
        }
        else if(score <= PlayerPrefs.GetInt("BestScore"))
        {
            newImg.SetActive(false);
        }

        playScoreText.text = score.ToString();
        bestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
    }

    // 캐럿 생성 함수
    void MakeCarrot()
    {
        Instantiate(carrot);
    }
}

