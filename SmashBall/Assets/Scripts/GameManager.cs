using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public InterstitialAds interstitialAds;
    public RewardedAds rewardedAds;

    private void Start()
    {
        CoinCalculator(0);
        Debug.Log(PlayerPrefs.GetInt("moneyy"));

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("FinishLine")) {

            if (PlayerPrefs.GetInt("Noads") == 0)
            {
                interstitialAds.LoadInterstitialAd();
            }
            rewardedAds.LoadRewardedAd();
            CoinCalculator(100);
            Debug.Log(PlayerPrefs.GetInt("moneyy"));
            uiManager.CoinTextUpdate();
            uiManager.FinishScreen();
            PlayerPrefs.SetInt("LevelIndex", PlayerPrefs.GetInt("LevelIndex" + 1));
        }
    }


    public void CoinCalculator(int money) {

        if (PlayerPrefs.HasKey("moneyy"))
        {

            int oldScore = PlayerPrefs.GetInt("moneyy");
            PlayerPrefs.SetInt("moneyy", oldScore + money);
        }
        else
        {
            PlayerPrefs.SetInt("moneyy", 0);

        } 
    }
}
