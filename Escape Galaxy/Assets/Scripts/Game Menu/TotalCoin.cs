using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCoin : MonoBehaviour
{

    public Text loot;

    // Start is called before the first frame update
    void Start()
    {
        loot.text = PlayerPrefs.GetInt("Coin").ToString();
    }
}
    

