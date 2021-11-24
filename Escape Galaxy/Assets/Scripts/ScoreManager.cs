using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
  public int score;
  public Text scoreDisplay;

  private int coin;
  private int coinIncrement = 2; // default 2

  void OnTriggerEnter2D(Collider2D other)
  {
    // display current score on game screen
    scoreDisplay.text = score.ToString();

    coinIncrement = Random.Range(1, 3);

    if (other.CompareTag("Star") || other.CompareTag("Empty"))
    {
      // add score and coin if star has collided with score manager
      coin += coinIncrement;
      score++;

      // values stored to be used later in other scripts 
      PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + coinIncrement);
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
