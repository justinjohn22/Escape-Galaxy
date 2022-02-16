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
    private bool _unlockPlayer = false;

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

    public void ShowAd(string scene, bool unlockPlayer) {
        Advertisement.Show("rewardedVideo");
        _currentScene = scene;
        _unlockPlayer = unlockPlayer;
    }

    public void OnUnityAdsDidError(string message) {
        Debug.LogError($"Unity Ads Error: {message}");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult) {
        switch (showResult){
            case ShowResult.Finished:
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 300);
                if (_currentScene == "GameOver"){
                    PlayerPrefs.SetInt("AdFinished", 1);
                }
                if (_unlockPlayer) {
                    PlayerPrefs.SetInt("ShipSix", 1);
                    _unlockPlayer = false;
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
