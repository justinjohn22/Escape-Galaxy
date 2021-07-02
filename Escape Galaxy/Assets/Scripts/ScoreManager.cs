using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;
    private int coin;

    void OnTriggerEnter2D(Collider2D other)
    {
        scoreDisplay.text = score.ToString();
        if (other.CompareTag("Star"))
        {
            coin += 2;
            score++;
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 2);
            PlayerPrefs.SetInt("CurrentCoin", coin);
            // Debug.Log(score);
        }

        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
