using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentCoin : MonoBehaviour
{

    public Text coinsCollected;
    public Text currentScore;
    public Text totalCoin;
    public Text highScore;

    private int RESET_VALUE = 0;
    private float startTime;
    private int score, coin, coinCollected;

    // Start is called before the first frame update
    void Start()
    {   
        // getting values from player prefs
        score = PlayerPrefs.GetInt("TempScore");
        coin = PlayerPrefs.GetInt("Coin") - PlayerPrefs.GetInt("CurrentCoin");
        
        // Debug.Log("coin: " + coin);
        coinCollected = PlayerPrefs.GetInt("CurrentCoin");
  
        // display the most resent score and coins collected by the player 
        coinsCollected.text = "+" + PlayerPrefs.GetInt("CurrentCoin").ToString();
        currentScore.text = PlayerPrefs.GetInt("TempScore").ToString();
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();

        // if current coin is zero, update if statement won't be called
        if (coinCollected == 0)
        {
            totalCoin.text = PlayerPrefs.GetInt("Coin").ToString();
        }
       
        // reset player prefs after values are stored
        ResetPlayerPrefs();
    }

    void Update()
    {   
        // to animation coins being added up in game over scene
        startTime = Time.time;
        if (startTime > 10.0f) // to slow to addition and substraction
        {
            if (coin < coin + coinCollected)
            {   
                // play the adding animation
                coin++;
                totalCoin.text = coin.ToString(); // display to screen
                coinCollected--;
                startTime = 0f;
            }
        }

    }

    private void ResetPlayerPrefs()
    {
        // reset values to be used again
        PlayerPrefs.SetInt("CurrentCoin", RESET_VALUE);
        PlayerPrefs.SetInt("TempScore", RESET_VALUE);
    }

}
