using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject walls;
    public GameObject coins;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public static bool GameOver;
    public static float EnemySpeed;
    public float time;
    public static int TotalScore;
    private static int _highScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    
    

    private void Start()
    {
        EnemySpeed = 3;
        Time.timeScale = 1;
        GameOver = false;
        TotalScore = 0;
        gameOverPanel.SetActive(false);
        StartCoroutine(MoveWalls());
        StartCoroutine(AppearStars());
    }

    void Update()
    {
        scoreText.text = "Score: " + TotalScore.ToString();
        highScoreText.text = "High Score: " + _highScore.ToString();
        if (TotalScore > _highScore)
        {
            _highScore = TotalScore;
        }
        time += Time.deltaTime;
        if (time >= 10 && EnemySpeed < 30)
        {
            EnemySpeed += 2;
            time = 0;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Time.timeScale == 1)
            {
                PauseGame();
            }
        }
        if (GameOver)
        {
            GameOverFunc();
        }
        
    }

    /*
     * Move the walls down so it will shown like infinity game.
     */
    private IEnumerator MoveWalls()
    {
        while (true)
        {
            GameObject newWalls = Instantiate(walls);
            newWalls.transform.position = new Vector3(4.90999985f,16.4799995f,-22.9036198f);
            Destroy(newWalls, 40);
            yield return new WaitForSeconds(12f);
        }
    }
    
    /*
     * Appear of the stars in random position on the screen,
     * and random time.
     */
    private IEnumerator AppearStars()
    {
        while (true)
        {
            float spawnY = Random.Range(4.5f,-4.5f);
            float spawnX = Random.Range(-6,6);
            float waitTime = Random.Range(1,8);
            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            GameObject newStars = Instantiate(coins, spawnPosition, Quaternion.identity);
            Destroy(newStars, 10);
            yield return new WaitForSeconds(waitTime);
        }
    }

    /*
     * Continuing the game by set the time scale to 1.
     */
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    
    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void GameOverFunc()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
    
}
