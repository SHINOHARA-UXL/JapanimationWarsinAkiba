using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text finalScoreText;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        int score = PlayerPrefs.GetInt("Score", 0);  
        finalScoreText.text = "Score: " + score;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoToMainMenu();
        }
    }

    public void RestartGame()//������x�V��
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GoToMainMenu()//�z�[���ɖ߂�
    {
        SceneManager.LoadScene("StartScene");
    }
}

