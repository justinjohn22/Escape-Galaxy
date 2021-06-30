using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int coin;
    private int coinIncrement = 25;

    void Start()
    {

    }

 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().coin += coinIncrement;
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + coinIncrement);
            Destroy(gameObject);
        }
    }
}
