using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    
    private float speedUp = 8;
    private float speedArrow = 3;
    public Rigidbody2D rigidB;
    public GameObject[] obstacles;
    public AudioSource pointMusic;
    public AudioSource gameOverSound;

    private void Start()
    {
       StartCoroutine(FallObstacle());
    }
    /*
     * Moving the player left and right by using the arrows,
     * and jump by space key.
     */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidB.velocity = Vector2.up * speedUp;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rigidB.velocity = Vector2.left * speedArrow;
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rigidB.velocity = Vector2.right * speedArrow;
        }
        
    }
    
    /*
     * Fall an obstacle birds from the sky , with random time
     * and random position on the screen.
     */
    private IEnumerator FallObstacle()
    {
        while (true)
        {
            int randomObstacle = Random.Range(0, obstacles.Length);
            GameObject obstacle = obstacles[randomObstacle];
            float randomTime = Random.Range(0.5f, 4f);
            float randomPosition = Random.Range(-6f, 6f);
            yield return new WaitForSeconds(randomTime);
            GameObject instant = Instantiate(obstacle, new Vector3(randomPosition, 5.65f , 0)
                , Quaternion.identity);
            Destroy(instant,5);
        }
    }
    /*
     * When the player collision with the enemy or the walls, the player
     * lose the game.
     */
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("wall"))
        {
            gameOverSound.Play();
            GameManager.GameOver = true;
        }
    }

    /*
     * When the player collide with a star, the score increase by 2.
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("star"))
        {
            GameManager.TotalScore += 2;
            pointMusic.Play();
            other.gameObject.SetActive(false);
        }
    }

    /*
     * If the player out of screen the game is over.
     */
    private void OnBecameInvisible()
    {
        gameOverSound.Play();
        GameManager.GameOver = true;
    }
}
