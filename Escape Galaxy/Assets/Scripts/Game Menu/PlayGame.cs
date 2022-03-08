using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{   
    private bool SPECIAL_AD = false;
    private int NO_COINS = 0;
    public void playGame()
    {   
        // load main game scene
        SceneManager.LoadScene("GameScene");
    }

    public void home()
    {   
        // load main menu
        SceneManager.LoadScene("Menu");
    }

    public void shop()
    {
        // load main menu
        SceneManager.LoadScene("Shop");
    }

    public void FreeCoin() {
        Scene scene = SceneManager.GetActiveScene();
        // Debug.Log("CURRENT SCENE: " + scene.name);
        AdManager.Instance.ShowAd(scene.name, SPECIAL_AD, SPECIAL_AD, NO_COINS);
    }

}
