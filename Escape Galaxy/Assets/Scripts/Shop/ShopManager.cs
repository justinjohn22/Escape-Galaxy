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
    public Text shipFourText;
    public Text shipFiveText;

    public Text totalCoins;

    private int SHIP_TWO_COST = 550;
    private int SHIP_THREE_COST = 850;
    private int SHIP_FOUR_COST = 1350;
    private int SHIP_FIVE_COST = 1850;

    void Start()
    {
        // default ship 
        PlayerPrefs.SetInt("ShipOne", 1);
     
        // initial text setup for selected ship
        Text[] textArray = new Text[] { shipOneText, shipTwoText, shipThreeText, shipFourText, shipFiveText };
        string[] savedList = new string[] { "ShipOne", "ShipTwo", "ShipThree", "ShipFour", "ShipFive" };


        textArray[PlayerPrefs.GetInt("SelectedPlayer")].text = "SELECTED";

        for (int i = 0; i < 5; ++i)
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
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - SHIP_THREE_COST);
                PlayerPrefs.SetInt("ShipThree", 1);
                shipThreeText.text = "SELECT";
            }
        }
    }

    // shop logic for ship 4
    public void shipFour()
    {
        // Debug.Log("Ship 2");

        if (PlayerPrefs.GetInt("ShipFour", 0) == 1)
        {
            PlayerPrefs.SetInt("SelectedPlayer", 3);
            shipFourText.text = "SELECTED";
            ResetText(3);
            LoadGameScene();
        }
        else if (PlayerPrefs.GetInt("ShipFour", 0) == 0)
        {
            if (PlayerPrefs.GetInt("Coin") - SHIP_FOUR_COST >= 0)
            {
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - SHIP_FOUR_COST);
                PlayerPrefs.SetInt("ShipFour", 1);
                shipFourText.text = "SELECT";
            }
        }
    }

    // shop logic for ship 4
    public void shipFive()
    {
        // Debug.Log("Ship 2");

        if (PlayerPrefs.GetInt("ShipFive", 0) == 1)
        {
            PlayerPrefs.SetInt("SelectedPlayer", 4);
            shipFourText.text = "SELECTED";
            ResetText(4);
            LoadGameScene();
        }
        else if (PlayerPrefs.GetInt("ShipFive", 0) == 0)
        {
            if (PlayerPrefs.GetInt("Coin") - SHIP_FIVE_COST >= 0)
            {
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - SHIP_FIVE_COST);
                PlayerPrefs.SetInt("ShipFive", 1);
                shipFiveText.text = "SELECT";
            }
        }
    }

    // resets all other ship text back to 'select' once a ship is 'selected'
    private void ResetText(int index)
    {
        Text[] textArray = new Text[] { shipOneText, shipTwoText, shipThreeText, shipFourText, shipFiveText };
        string[] savedList = new string[] { "ShipOne", "ShipTwo", "ShipThree", "ShipFour", "ShipFive" };

        for (int i = 0; i < 5; ++i)
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
