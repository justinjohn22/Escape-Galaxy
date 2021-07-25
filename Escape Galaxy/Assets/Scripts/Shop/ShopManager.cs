using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Text shipOneText;
    public Text shipTwoText;
    public Text shipThreeText;

    public Text totalCoins;


    private int SHIP_TWO_COST = 550;
    private int SHIP_THREE_COST = 850;

    void Start()
    {
        // default ship 
        PlayerPrefs.SetInt("ShipOne", 1);

        // initial text setup for selected ship
        Text[] textArray = new Text[] { shipOneText, shipTwoText, shipThreeText };
        string[] savedList = new string[] { "ShipOne", "ShipTwo", "ShipThree" };


        textArray[PlayerPrefs.GetInt("SelectedPlayer")].text = "SELECTED";

        for (int i = 0; i < 3; ++i)
        {   
            if (PlayerPrefs.GetInt(savedList[i]) == 0)
            {
                textArray[i].text = "BUY";

            } else if (PlayerPrefs.GetInt(savedList[i]) == 1 && PlayerPrefs.GetInt("SelectedPlayer") != i)
            {
                textArray[i].text = "SELECT";
            }
        }
    }

    void Update() 
    {
        totalCoins.text = PlayerPrefs.GetInt("Coin").ToString();
    }
    
    // shop logic for ship 1
    public void shipOne()
    {
        PlayerPrefs.SetInt("SelectedPlayer", 0);
        shipOneText.text = "SELECTED";
        ResetText(0);
        LoadGameScene();
        // Debug.Log("Ship 0");
    }

    // shop logic for ship 2
    public void shipTwo()
    {
        if (PlayerPrefs.GetInt("ShipTwo", 0) == 1)
        {
            PlayerPrefs.SetInt("SelectedPlayer", 1);
            shipTwoText.text = "SELECTED";
            ResetText(1);
            LoadGameScene();
        } 
        else if (PlayerPrefs.GetInt("ShipTwo", 0) == 0)
        {
            if (PlayerPrefs.GetInt("Coin") - SHIP_TWO_COST >= 0)
            {
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - SHIP_TWO_COST);
                PlayerPrefs.SetInt("ShipTwo", 1);
                shipTwoText.text = "SELECT";
            }
        }
           
        // Debug.Log("Ship 1");
    }

    // shop logic for ship 3
    public void shipThree()
    { 
        // Debug.Log("Ship 2");

        if (PlayerPrefs.GetInt("ShipThree", 0) == 1)
        {
            PlayerPrefs.SetInt("SelectedPlayer", 2);
            shipThreeText.text = "SELECTED";
            ResetText(2);
            LoadGameScene();
        }
        else if (PlayerPrefs.GetInt("ShipThree", 0) == 0)
        {
            if (PlayerPrefs.GetInt("Coin") - SHIP_THREE_COST >= 0)
            {
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - SHIP_TWO_COST);
                PlayerPrefs.SetInt("ShipThree", 1);
                shipThreeText.text = "SELECT";
            }
        }
    }

    // resets all other ship text back to 'select' once a ship is 'selected'
    private void ResetText(int index)
    {
        Text[] textArray = new Text[] { shipOneText, shipTwoText, shipThreeText };
        string[] savedList = new string[] { "ShipOne", "ShipTwo", "ShipThree" };

        for (int i = 0; i < 3; ++i)
        {
            if (i != index && PlayerPrefs.GetInt(savedList[i]) == 1)
            {
                textArray[i].text = "SELECT";
            }
        }
    }

    // automatic game scene load after a ship is selected
    private void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
