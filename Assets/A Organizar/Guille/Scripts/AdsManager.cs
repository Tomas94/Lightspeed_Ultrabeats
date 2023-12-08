using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] string _gameID = "5494318", _adId = "Rewarded_Android";
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

    public void showAd()
    {
        if (!Advertisement.IsReady()) return;

        Advertisement.Show(_adId);
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
        if (placementid == _adId)
        {
            if (showresult == ShowResult.Finished)
            {
                Debug.Log("Consigue recompensas");
                
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
