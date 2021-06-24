using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;

    void Start()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        scoreDisplay.text = score.ToString();
        if (other.CompareTag("Star"))
        {
            score++;
            Debug.Log(score);
        }
    }
}
