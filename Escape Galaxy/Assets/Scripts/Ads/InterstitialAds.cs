using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour
{
    [SerializeField] private bool testMode = true;

#if UNITY_ANDROID
    private string gameId = "4488257";
    private string adID = "Interstitial_Android";
#elif UNITY_IOS
    private string gameId = "4488256";
    private string adID = "Interstitial_iOS";
#endif

    void Start() 
    {
        Advertisement.Initialize(gameId, testMode);
        PlayerPrefs.SetInt("AdCount", PlayerPrefs.GetInt("AdCount", 0) + 1);
        if (PlayerPrefs.GetInt("AdCount", 0) == 10) {
            if (Advertisement.IsReady(adID)) {
                Advertisement.Show(adID);
            }
            PlayerPrefs.SetInt("AdCount", 0);
        }
    } 

    // Update is called once per frame
    void Update()
    {   
        
    }
}
