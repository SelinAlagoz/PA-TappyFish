using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{   
    public static Vector2 bottomleft;
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool gameStarted; //As long as the game doesn't start, we want to have a waiting moment, keep the fish in the air, and not produce obstacles.
    public GameObject GetReady;
    public static int gameScore;
    public GameObject score;
    // Start is called before the first frame update

    private void Awake() //Because we want it to run before the start.
    {
        bottomleft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)); //We want to find the bottom left corner of the screen.
        
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Start()
    {
        gameOver = false;
        gameStarted = false; 
    }

    // Update is called once per frame

    public void GameHasStarted()
    {
        gameStarted = true;
        GetReady.SetActive(false);
    }
    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        score.SetActive(false);
        gameScore = score.GetComponent<Score>().GetScore();
    }
    void Update()
    {
        
    }
}
