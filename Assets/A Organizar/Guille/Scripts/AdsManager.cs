using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] string _gameID = "5494318", _coinsAd = "Coins_Rewarded_Android", _upgradePAd = "UP_Rewarded_Android", _staminaAd = "Stamina_Rewarded_Android";
    public Currency currency;

    private static bool isInitialized = false;

    void Start()
    {
        if (!isInitialized)
        {
            Advertisement.AddListener(this);
            Advertisement.Initialize(_gameID);
            isInitialized = true;
        }
    }

    public void showAd(string adID)
    {
        if (!Advertisement.IsReady()) return;

        Advertisement.Show(adID);
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ad is ready to show");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad is playing");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Ad is failing");
    }

    public void OnUnityAdsDidFinish(string placementid, ShowResult showresult)
    {
        if (placementid == _coinsAd)
        {
            if (showresult == ShowResult.Finished)
            {
                Debug.Log("Consigue recompensas");
                _currencyManager.instance.GainCurrency(25);

            }
            else if (showresult == ShowResult.Skipped)
            {
                Debug.Log("No hay recompensas");
                _currencyManager.instance.GainCurrency(5);
            }
            else if (showresult == ShowResult.Failed)
            {
                Debug.Log("No hay recompensas");
            }
        }

        if (placementid == _upgradePAd)
        {
            if (showresult == ShowResult.Finished)
            {
                Debug.Log("Consigue recompensas");
                UpgradePointsManager.instance.GainUP(5);

            }
            else if (showresult == ShowResult.Skipped)
            {
                Debug.Log("No hay recompensas");
            }
            else if (showresult == ShowResult.Failed)
            {
                Debug.Log("No hay recompensas");
            }
        }

        if (placementid == _staminaAd)
        {
            if (showresult == ShowResult.Finished)
            {
                Debug.Log("Consigue recompensas");
                StaminaManager.instance.RechargeStamina();
            }
            else if (showresult == ShowResult.Skipped)
            {
                Debug.Log("No hay recompensas");
            }
            else if (showresult == ShowResult.Failed)
            {
                Debug.Log("No hay recompensas");
            }
        }
    }

}
