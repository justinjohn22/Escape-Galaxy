using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class AdManager : MonoBehaviour, IUnityAdsListener
{   
    [SerializeField] private bool testMode = true;

#if UNITY_ANDROID
    private string gameId = "4488257";
#elif UNITY_IOS
    private string gameId = "4488256";
#endif

    public static AdManager Instance;
    private string _currentScene = "null";
    private bool _unlockPlayer, _doubleCoins = false;
    private int _doubleAmount = 0;
    private int REWARD_AMOUNT = 300;
    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId, testMode);
        }
    }   

    public void ShowAd(string scene, bool unlockPlayer, bool doubleCoins, int doubleAmount) {
        Advertisement.Show("rewardedVideo");
        _currentScene = scene;
        _unlockPlayer = unlockPlayer;
        _doubleAmount = doubleAmount;
        _doubleCoins = doubleCoins;
    }

    public void OnUnityAdsDidError(string message) {
        Debug.LogError($"Unity Ads Error: {message}");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult) {
        Debug.Log("Ad platform: " + gameId);
        switch (showResult){
            case ShowResult.Finished:  
                if (_currentScene == "GameOver" && !_doubleCoins){
                    PlayerPrefs.SetInt("AdFinished", 1);
                }
                if (_unlockPlayer && !_doubleCoins) {
                    PlayerPrefs.SetInt("ShipSix", 1);
                    _unlockPlayer = false;
                } else {
                    if (!_doubleCoins) {
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + REWARD_AMOUNT);
                    }
                }
                if (_doubleCoins) {
                    PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + _doubleAmount);
                    PlayerPrefs.SetInt("CoinDoubled", 1);
                }
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad Skipped");
                break;
            case ShowResult.Failed:
                Debug.LogWarning("Ad Failed");
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId) {
        Debug.Log("Ad Started");
    }

    public void OnUnityAdsReady(string placementId) {
        Debug.Log("Unity Ads Ready");

    }

}
