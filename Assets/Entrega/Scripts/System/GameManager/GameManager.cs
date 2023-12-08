using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<SkinsStruct> skins = new List<SkinsStruct>();
    public List<bool> skinavailable = new List<bool>();
    public Material playerskin;
    public int levelsUnlock = 1;
    public bool sound;
    [RangeAttribute(0f, 0.7f)] public float brillo;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(this);
        DontDestroyOnLoad(this);
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
        //vibration = PlayerPrefs.GetInt("Vibration", 0) == 1;

        brillo = PlayerPrefs.GetFloat("brillo", 0.35f);
        CurrencyManager.instance.SetCurrencyValues(PlayerPrefs.GetInt("currency", 0));
        StaminaManager.instance.SetStaminaValues(PlayerPrefs.GetInt("stamina",5));
        UpgradePointsManager.instance.SetUPValues(PlayerPrefs.GetInt("upgradePoints", 0));
        levelsUnlock = PlayerPrefs.GetInt("levelsUnlock", 1);
        skinavailable = LoadBooleanList();
    }

    public void SavePlayerPrefs()
    {
        PlayerPrefs.SetFloat("brillo", brillo);
        PlayerPrefs.SetInt("currency", CurrencyManager.instance.Currency);
        PlayerPrefs.SetInt("stamina", StaminaManager.instance.Stamina);
        PlayerPrefs.SetInt("upgradePoints", UpgradePointsManager.instance.UpgradePoints);
        PlayerPrefs.SetInt("levelsUnlock", levelsUnlock);
        SaveBooleanList(skinavailable);
    }

    public void ResetProgress()
    {
        PlayerPrefs.SetFloat("brillo", 0.35f);
        PlayerPrefs.SetInt("currency", 0);
        PlayerPrefs.SetInt("stamina", 5);
        PlayerPrefs.SetInt("upgradePoints", 0);
        PlayerPrefs.SetInt("levelsUnlock", 1);

        List<bool> resetList = new List<bool>() { true, false, false, false };
        SaveBooleanList(resetList);

        LoadPlayerPreferencies();
        SceneManagerr.ResetGame();
    }

    private void SaveBooleanList(List<bool> list)
    {
        // Convertir la lista de booleanos a una cadena de texto
        string booleanListString = string.Join(",", list.Select(b => b ? "1" : "0").ToArray());

        // Guardar la cadena en PlayerPrefs
        PlayerPrefs.SetString("skinsUnlock", booleanListString);
    }

    // Método para cargar la lista de booleanos desde PlayerPrefs
    private List<bool> LoadBooleanList()
    {
        // Obtener la cadena de PlayerPrefs
        string loadedBooleanListString = PlayerPrefs.GetString("skinsUnlock", "1,0,0,0");

        // Dividir la cadena en un array de strings
        string[] booleanArrayString = loadedBooleanListString.Split(',');

        // Convertir el array de strings a un array de booleanos
        List<bool> loadedBooleanList = booleanArrayString.Select(s => s == "1").ToList();

        return loadedBooleanList;
    }

    #endregion

    private void OnApplicationQuit() => SavePlayerPrefs();

}
