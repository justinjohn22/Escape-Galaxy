using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{

    public void shipOne()
    {
        PlayerPrefs.SetInt("SelectedPlayer", 0);
        SceneManager.LoadScene("GameScene");
       // Debug.Log("Ship 0");
    }

    public void shipTwo()
    {
        PlayerPrefs.SetInt("SelectedPlayer", 1);
        SceneManager.LoadScene("GameScene");
       // Debug.Log("Ship 1");
    }

    public void shipThree()
    {
        PlayerPrefs.SetInt("SelectedPlayer", 2);
        SceneManager.LoadScene("GameScene");
        // Debug.Log("Ship 2");
    }
}
