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
    public Text shipSixText;
    public Text shipSevenText;
    public Text shipEightText;

    public Text totalCoins;
 
    private int SHIP_TWO_COST = 550;
    private int SHIP_THREE_COST = 850;
    private int SHIP_FOUR_COST = 1350;
    private int SHIP_FIVE_COST = 1850;
    private int SHIP_SIX_COST = 15;
    private int SHIP_SEVEN_COST = 10000;
    private int SHIP_EIGHT_COST = 15000;


    private int shipNumber = 8;

    void Start()
    {
        // default ship 
        PlayerPrefs.SetInt("ShipOne", 1);

        // PlayerPrefs.DeleteAll();

        // initial text setup for selected ship
        Text[] textArray = new Text[] { shipOneText, shipTwoText, shipThreeText, 
                                        shipFourText, shipFiveText, shipSixText, 
                                        shipSevenText, shipEightText };

        string[] savedList = new string[] { 
                                        "ShipOne", "ShipTwo", "ShipThree", 
                                        "ShipFour", "ShipFive", "ShipSix", 
                                        "ShipSeven", "ShipEight" };

        int[] cost_array = new int[] { SHIP_TWO_COST, SHIP_THREE_COST, 
                                       SHIP_FOUR_COST, SHIP_FIVE_COST, 
                                       SHIP_SIX_COST, SHIP_SEVEN_COST,
                                       SHIP_EIGHT_COST };

        textArray[PlayerPrefs.GetInt("SelectedPlayer")].text = "SELECTED";

        for (int i = 0; i < shipNumber; ++i)
        {   
            if (PlayerPrefs.GetInt(savedList[i]) == 0 && i != 0)
            {   
                if (i != 5) {
                    textArray[i].text = (cost_array[i - 1]).ToString();
                } else {
                     textArray[i].text = "Free";
                }
                
            } 
            else if (PlayerPrefs.GetInt(savedList[i]) == 1 
                && PlayerPrefs.GetInt("SelectedPlayer") != i)
            {
                textArray[i].text = "SELECT";
            }
        }
    }

    void Update() 
    {
        totalCoins.text = PlayerPrefs.GetInt("Coin").ToString();
    }
     
    // FOR TESTING -> REMOVE BEFORE PRODUCTION 
    public void addCoin()
    {
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 500);
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

    // shop logic for ship 5
    public void shipFive()
    {
        // Debug.Log("Ship 2");

        if (PlayerPrefs.GetInt("ShipFive", 0) == 1)
        {
            PlayerPrefs.SetInt("SelectedPlayer", 4);
            shipFiveText.text = "SELECTED";
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

    // shop logic for ship 6
    public void shipSix()
    {
        // Debug.Log("Ship 2");

        if (PlayerPrefs.GetInt("ShipSix", 0) == 1)
        {
            PlayerPrefs.SetInt("SelectedPlayer", 5);
            shipSixText.text = "SELECTED";
            ResetText(5);
            LoadGameScene();
        }
        else if (PlayerPrefs.GetInt("ShipSix", 0) == 0)
        {   
            AdManager.Instance.ShowAd("stub", true, false, 0);
            if (PlayerPrefs.GetInt("ShipSix", 0) == 0) {
                shipSixText.text = "SELECT";
            }
        }
    }

    // shop logic for ship 7
    public void shipSeven()
    {
        // Debug.Log("Ship 2");

        if (PlayerPrefs.GetInt("ShipSeven", 0) == 1)
        {
            PlayerPrefs.SetInt("SelectedPlayer", 6);
            shipSevenText.text = "SELECTED";
            ResetText(6);
            LoadGameScene();
        }
        else if (PlayerPrefs.GetInt("ShipSeven", 0) == 0)
        {
            if (PlayerPrefs.GetInt("Coin") - SHIP_SEVEN_COST >= 0)
            {
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - SHIP_SEVEN_COST);
                PlayerPrefs.SetInt("ShipSeven", 1);
                shipSevenText.text = "SELECT";
            }
        }
    }

    // shop logic for ship 7
    public void shipEight()
    {
        // Debug.Log("Ship 2");

        if (PlayerPrefs.GetInt("ShipEight", 0) == 1)
        {
            PlayerPrefs.SetInt("SelectedPlayer", 7);
            shipEightText.text = "SELECTED";
            ResetText(7);
            LoadGameScene();
        }
        else if (PlayerPrefs.GetInt("ShipEight", 0) == 0)
        {
            if (PlayerPrefs.GetInt("Coin") - SHIP_EIGHT_COST >= 0)
            {
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - SHIP_EIGHT_COST);
                PlayerPrefs.SetInt("ShipEight", 1);
                shipEightText.text = "SELECT";
            }
        }
    }

    // resets all other ship text back to 'select' once a ship is 'selected'
    private void ResetText(int index)
    {
        // initial text setup for selected ship
        Text[] textArray = new Text[] { shipOneText, shipTwoText, shipThreeText,
                                        shipFourText, shipFiveText, shipSixText,
                                        shipSevenText, shipEightText };

        string[] savedList = new string[] {"ShipOne", "ShipTwo", "ShipThree",
                                           "ShipFour", "ShipFive", "ShipSix",
                                           "ShipSeven", "ShipEight" };

        for (int i = 0; i < shipNumber; ++i)
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
