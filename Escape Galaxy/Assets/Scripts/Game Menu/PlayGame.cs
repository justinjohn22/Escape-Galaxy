using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
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

}
