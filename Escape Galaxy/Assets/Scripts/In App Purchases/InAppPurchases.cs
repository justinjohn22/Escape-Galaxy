using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class InAppPurchases : MonoBehaviour
{
   [SerializeField] private GameObject restoreButton; 

   private const string CoinsLevelOneId = "com.dotexecute.escapegalaxy.coinslevelone";

   private void Awake() {
       if (Application.platform != RuntimePlatform.IPhonePlayer) {
           restoreButton.SetActive(false);
       }
   }

    public void OnPurchaseComplete(Product product) 
    {   
        if (product.definition.id == CoinsLevelOneId) {
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 5000);
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason) 
    {
        Debug.LogWarning($"Failed to add 5000 coins due to {reason}.");
    }

}
