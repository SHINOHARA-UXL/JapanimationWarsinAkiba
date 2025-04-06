using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreControler : MonoBehaviour
{
    public static ScoreControler instance;

    public Text scoreText;
    public Text timerText;

    public static int score = 0;
    private float timeRemaining = 60f;
    private bool isGameOver = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        score = 0;  // スコアのリセット
        timeRemaining = 60f;  // タイマーのリセット
        Debug.Log(timeRemaining);
        isGameOver = false;
        Debug.Log(isGameOver);
        //UpdateScoreUI();
        //UpdateTimerUI();
    }

    void Start()
    {
        UpdateScoreUI();
        UpdateTimerUI();
        Debug.Log(9);
    }

    void Update()
    {
        //Debug.Log(timeRemaining);
        if (!isGameOver)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();
           // Debug.Log(1);
           // Debug.Log(timeRemaining);
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                GameOver();
            }
        }
    }

    public void AddScore(int points)
    {
        if (!isGameOver)
        {
            score += points;
            UpdateScoreUI();
        }
    }

    void UpdateTimerUI()
    {
        timerText.text = "Time: " + Mathf.Max(0, Mathf.FloorToInt(timeRemaining));
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    void GameOver()
    {
        Debug.Log(5);
        isGameOver = true;
        timerText.text = "Time: 0";
        Debug.Log("Game Over! Your Score: " + score);
        PlayerPrefs.SetInt("Score", score);

        Invoke("LoadGameOverScene", 0.1f);
    }

    void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene"); 
    }

    public static int GetScore()
    {
        return score;
    }

    public void StartGame()
    {
        score = 0;  // スコアのリセット
        timeRemaining = 60f;  // タイマーのリセット
        isGameOver = false;   // ゲームオーバーフラグのリセットS
        Debug.Log(1);
        UpdateScoreUI();
        UpdateTimerUI();
    }

}

