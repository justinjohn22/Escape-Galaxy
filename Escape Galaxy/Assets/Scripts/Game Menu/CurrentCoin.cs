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
    public Text GameOverCause;
    public Button doubleCoinButton;
    
    private int RESET_VALUE = 0;
    private float startTime;
    private int score, coin, coinCollected, coinForAd;

    // Start is called before the first frame update
    void Start()
    {   
        //button.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 100);

        // getting values from player prefs
        score = PlayerPrefs.GetInt("TempScore");
        coin = PlayerPrefs.GetInt("Coin") - PlayerPrefs.GetInt("CurrentCoin");

        if (PlayerPrefs.GetString("GameOverCause").Equals("health"))
        {
            GameOverCause.text = "Ship Destroyed!";
        } 
        else if (PlayerPrefs.GetString("GameOverCause").Equals("fuel"))
        {
            GameOverCause.text = "Out of Fuel!";
        }

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

        coinForAd = coinCollected;

        // reset player prefs after values are stored
        ResetPlayerPrefs();
    }

    void Update()
    {   
        // to animate coins being added up in game over scene
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

        if (PlayerPrefs.GetInt("AdFinished") == 1) {
            totalCoin.text = PlayerPrefs.GetInt("Coin").ToString();
            coinCollected += 300;
            PlayerPrefs.SetInt("AdFinished", 0);
        }

        if (PlayerPrefs.GetInt("CoinDoubled") == 1) {
            coinCollected += coinForAd;
            coinsCollected.text = "+" + coinForAd * 2;
            PlayerPrefs.SetInt("CoinDoubled", 0);
        }

    }
    public void DoubleCoin() {
        if (PlayerPrefs.GetInt("DisableDoubleButton", 0) == 0 && coinForAd > 0) {
            bool doubleCoins = true;
            string scene = "NO_SCENE_REQUIRED";
            bool SPECIAL_AD = false;
            // Debug.Log("Double Amount: " + coinForAd);
            AdManager.Instance.ShowAd(scene, SPECIAL_AD, doubleCoins, coinForAd);
            PlayerPrefs.SetInt("DisableDoubleButton", 1);
        }
    }

    private void ResetPlayerPrefs()
    {
        // reset values to be used again
        PlayerPrefs.SetInt("CurrentCoin", RESET_VALUE);
        PlayerPrefs.SetInt("TempScore", RESET_VALUE);
    }

}
