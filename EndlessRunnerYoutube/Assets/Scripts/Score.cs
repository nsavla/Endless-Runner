using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int score;
    public Text scoreDisplay;
    public Text highScoreDisplay;

    private void Update()
    {
        scoreDisplay.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        score++;
        Destroy(other.gameObject);
    }

    public int getScore()
    {
        return score;
    }

    public int getHighScore()
    {
        return PlayerPrefs.GetInt("highestScore");
    }

    public void setHighScore()
    {
        if ((!PlayerPrefs.HasKey("highestScore")) || (score > PlayerPrefs.GetInt("highestScore"))) 
        {
            PlayerPrefs.SetInt("highestScore", score);
        }
        highScoreDisplay.text = PlayerPrefs.GetInt("highestScore").ToString();
    }
}
