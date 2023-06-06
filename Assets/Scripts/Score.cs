using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added later.

public class Score : MonoBehaviour
{
    int score;
    Text scoreText;
    int highScore;

    public Text panelScore;
    public Text panelHighScore;
    public GameObject New;
    // Start is called before the first frame update
    void Start()
    {
        score = 0; //our initial value.
        scoreText = GetComponent<Text>(); //We will access the text component and update the text there
        scoreText.text = score.ToString(); //Our score is an int value, but since it is a string in the editor, we convert it to a string.
        panelScore.text = score.ToString(); 
        highScore = PlayerPrefs.GetInt("highscore");
        panelHighScore.text = highScore.ToString();
    }
    public void Scored(){
        score++;
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();
        if(score > highScore)
        {
            highScore = score;
            panelHighScore.text = highScore.ToString();
            PlayerPrefs.SetInt("highscore",highScore);     //https://www.urhoba.net/2021/11/unity-playerprefs-nedir-nasl-kullanlr.html
            PlayerPrefs.Save();
            New.SetActive(true);
        }
    }
    public int GetScore()
    {
        return score;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
