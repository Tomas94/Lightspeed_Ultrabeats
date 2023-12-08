using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] string _gameID = "5494318", _staminaId= "Rewarded_Android", _upgradePointsId = "UpgradePoints_Rewards";
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

    public void showAd(string id)
    {
        if (!Advertisement.IsReady()) return;

        Advertisement.Show(id);
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
        if (placementid == _staminaId)
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
        if (placementid == _upgradePointsId)
        {
            if (showresult == ShowResult.Finished)
            {
                Debug.Log("Consigue recompensas");
                UpgradePointsManager.instance.GainUPByAds(5);
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
