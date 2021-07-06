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
        // display current score on game screen
        scoreDisplay.text = score.ToString();

        if (other.CompareTag("Star"))
        {   
            // add score and coin if star has collided with score manager
            coin += 2;
            score++;
            
            // values stored to be used later in other scripts 
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 2);
            PlayerPrefs.SetInt("CurrentCoin", coin);
            PlayerPrefs.SetInt("TempScore", score);
            // Debug.Log(score);
        }


        // check if new high score has reached, set new high score 
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
