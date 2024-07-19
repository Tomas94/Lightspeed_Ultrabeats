using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<SkinsStruct> skins = new List<SkinsStruct>();
    public List<bool> skinavailable = new List<bool>();
    public Material playerskin;
    public int levelsUnlock;
    public bool sound;

    public Dictionary<string, int> upgradeBarLevel = new Dictionary<string, int>
    {
        {"vitality" , 1},
        {"damage" , 1},
        {"shield",1},
        {"wave",1}
    };

    [RangeAttribute(0f, 0.7f)] public float brillo;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
        //Opciones
        //vibration = PlayerPrefs.GetInt("Vibration", 0) == 1;
        brillo = PlayerPrefs.GetFloat("brillo", 0.35f);

        //Valores de progreso

        CurrencyManager.instance.SetCurrencyValues(PlayerPrefs.GetInt("currency", 0));
        StaminaManager.instance.SetStaminaValues(PlayerPrefs.GetInt("stamina", 5));
        UpgradePointsManager.instance.SetUPValues(PlayerPrefs.GetInt("upgradePoints", 0));
        levelsUnlock = PlayerPrefs.GetInt("levelsUnlock", 0);
        skinavailable = LoadBooleanList();

        //Stats jugador

        upgradeBarLevel["vitality"] = PlayerPrefs.GetInt("maxLifeBar", 1);
        upgradeBarLevel["damage"] = PlayerPrefs.GetInt("damageBar", 1);
        upgradeBarLevel["shield"] = PlayerPrefs.GetInt("shieldBar", 1);
        upgradeBarLevel["wave"] = PlayerPrefs.GetInt("waveBar", 1);

        Player_Stats_Manager.instance.MaxLife = PlayerPrefs.GetFloat("maxLife", 7);
        Player_Stats_Manager.instance.Damage = PlayerPrefs.GetFloat("damage", 1);
        Player_Stats_Manager.instance.ShieldDuration = PlayerPrefs.GetFloat("shieldDuration", 5);
        Player_Stats_Manager.instance.WaveDuration = PlayerPrefs.GetFloat("waveDuration", 8);
    }

    public void SavePlayerPrefs()
    {
        //Opciones
        PlayerPrefs.SetFloat("brillo", brillo);

        //Valores de progreso
        PlayerPrefs.SetInt("currency", CurrencyManager.instance.Currency);
        PlayerPrefs.SetInt("stamina", StaminaManager.instance.Stamina);
        PlayerPrefs.SetInt("upgradePoints", UpgradePointsManager.instance.UpgradePoints);
        PlayerPrefs.SetInt("levelsUnlockk", levelsUnlock);
        SaveBooleanList(skinavailable);

        //Stats jugador

        PlayerPrefs.SetInt("maxLifeBar", upgradeBarLevel["vitality"]);
        PlayerPrefs.SetInt("damageBar", upgradeBarLevel["damage"]);
        PlayerPrefs.SetInt("shieldBar", upgradeBarLevel["shield"]);
        PlayerPrefs.SetInt("waveBar", upgradeBarLevel["wave"]);

        PlayerPrefs.SetFloat("maxLife", Player_Stats_Manager.instance.MaxLife);
        PlayerPrefs.SetFloat("damage", Player_Stats_Manager.instance.Damage);
        PlayerPrefs.SetFloat("shieldDuration", Player_Stats_Manager.instance.ShieldDuration);
        PlayerPrefs.SetFloat("waveDuration", Player_Stats_Manager.instance.WaveDuration);
    }

    public void ResetProgress()
    {
        PlayerPrefs.SetFloat("brillo", 0.35f);
        PlayerPrefs.SetInt("currency", 0);
        PlayerPrefs.SetInt("stamina", 5);
        PlayerPrefs.SetInt("upgradePoints", 1000);
        PlayerPrefs.SetInt("levelsUnlock", 0);

        List<bool> resetList = new List<bool>() { true, false, false, false };
        SaveBooleanList(resetList);

        PlayerPrefs.SetInt("maxLifeBar", 1);
        PlayerPrefs.SetInt("damageBar", 1);
        PlayerPrefs.SetInt("shieldBar", 1);
        PlayerPrefs.SetInt("waveBar", 1);

        PlayerPrefs.SetFloat("maxLife", 7);
        PlayerPrefs.SetFloat("damage", 1);
        PlayerPrefs.SetFloat("shieldDuration", 5);
        PlayerPrefs.SetFloat("waveDuration", 8);

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
