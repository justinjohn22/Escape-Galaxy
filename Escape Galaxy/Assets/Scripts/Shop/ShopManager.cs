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

    void Start()
    {
        Text[] textArray = new Text[] { shipOneText, shipTwoText, shipThreeText };
        textArray[PlayerPrefs.GetInt("SelectedPlayer")].text = "SELECTED";
    }

    public void shipOne()
    {
        PlayerPrefs.SetInt("SelectedPlayer", 0);
        shipOneText.text = "SELECTED";
        ResetText(0);
        LoadGameScene();
        // Debug.Log("Ship 0");
    }

    public void shipTwo()
    {
        PlayerPrefs.SetInt("SelectedPlayer", 1);
        shipTwoText.text = "SELECTED";
        ResetText(1);
        LoadGameScene();
        // Debug.Log("Ship 1");
    }

    public void shipThree()
    {
        PlayerPrefs.SetInt("SelectedPlayer", 2);
        shipThreeText.text = "SELECTED";
        ResetText(2);
        LoadGameScene();
        // Debug.Log("Ship 2");
    }

  
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

    private void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
