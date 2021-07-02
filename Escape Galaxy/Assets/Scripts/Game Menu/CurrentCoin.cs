using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentCoin : MonoBehaviour
{

    public Text coinsCollected;

    // Start is called before the first frame update
    void Start()
    {
        coinsCollected.text = PlayerPrefs.GetInt("CurrentCoin").ToString();
        PlayerPrefs.SetInt("CurrentCoin", 0);
    }

}
