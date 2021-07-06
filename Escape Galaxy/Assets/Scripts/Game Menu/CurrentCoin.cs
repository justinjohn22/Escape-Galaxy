using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentCoin : MonoBehaviour
{

    public Text coinsCollected;
    public Text currentScore;

    private int RESET_VALUE = 0;

    // Start is called before the first frame update
    void Start()
    {   
        // display the most resent score and coins collected by the player 
        coinsCollected.text = PlayerPrefs.GetInt("CurrentCoin").ToString();
        currentScore.text = PlayerPrefs.GetInt("TempScore").ToString();

        // reset values to be used again
        PlayerPrefs.SetInt("CurrentCoin", RESET_VALUE);
        PlayerPrefs.SetInt("TempScore", RESET_VALUE);
    }

}
