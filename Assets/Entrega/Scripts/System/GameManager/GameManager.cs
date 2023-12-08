using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<SkinsStruct> skins = new List<SkinsStruct>();
    public List<bool> skinavailable = new List<bool>();
    public Material playerskin;


    [Header("Configuration Values")]
    public bool vibration;
    //[RangeAttribute(0f, 0.5f)] public float brigthnessValue;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(gameObject);
    }

    private void Start() { LoadPlayerPreferencies(); }

    public void ChangeSkin(string _id)
    {
        SkinsStruct valorencontrado = skins.Find(item => item.id == _id);

        if (valorencontrado.id != null) playerskin = valorencontrado.skin;

    }




    #region PlayerPrefs
    public void LoadPlayerPreferencies()
    {
        vibration = PlayerPrefs.GetInt("Vibration", 0) == 1;
        //brigthnessValue = PlayerPrefs.GetFloat("BrightnessValue", 0.25f);

        CurrencyManager.instance.Currency = PlayerPrefs.GetInt("currency", 0);
        StaminaManager.instance.Stamina = PlayerPrefs.GetInt("stamina");
        UpgradePointsManager.instance.UpgradePoints = PlayerPrefs.GetInt("upgradePoints", 0);
    }

    public void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("currency", CurrencyManager.instance.Currency);
        PlayerPrefs.SetInt("stamina", StaminaManager.instance.Stamina);
        PlayerPrefs.SetInt("upgradePoints", UpgradePointsManager.instance.UpgradePoints);
        //PlayerPrefs.SetInt("levelspassed",);
        //PlayerPrefs.SetString("skinsOwned",);
    }

    public void ResetProgress()
    {
        PlayerPrefs.SetInt("currency", 0);
        PlayerPrefs.SetInt("stamina", 5);
        PlayerPrefs.SetInt("upgradePoints", 0);
        LoadPlayerPreferencies();
        //PlayerPrefs.SetInt("levelspassed",0);
        //PlayerPrefs.SetString("skinsOwned",0);
        SceneManagerr.ResetGame();
    }
    #endregion

    private void OnApplicationQuit() => SavePlayerPrefs();

}
