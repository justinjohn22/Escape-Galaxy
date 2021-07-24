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

    void Start()
    {   
        // initial text setup for selected ship
        Text[] textArray = new Text[] { shipOneText, shipTwoText, shipThreeText };
        textArray[PlayerPrefs.GetInt("SelectedPlayer")].text = "SELECTED";
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
        PlayerPrefs.SetInt("SelectedPlayer", 1);
        shipTwoText.text = "SELECTED";
        ResetText(1);
        LoadGameScene();
        // Debug.Log("Ship 1");
    }

    // shop logic for ship 3
    public void shipThree()
    {
        PlayerPrefs.SetInt("SelectedPlayer", 2);
        shipThreeText.text = "SELECTED";
        ResetText(2);
        LoadGameScene();
        // Debug.Log("Ship 2");
    }

    // resets all other ship text back to 'select' once a ship is 'selected'
    private void ResetText(int index)
    {
        Text[] textArray = new Text[] { shipOneText, shipTwoText, shipThreeText };
       
        for (int i = 0; i < 3; ++i)
        {
            if (i != index)
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
