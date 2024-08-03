using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade_Store : MonoBehaviour
{
    Player_Stats_Manager playerStats;

    [Range(0, 10)] public int vitalityBar;
    [Range(0, 10)] public int damageBar;
    [Range(0, 10)] public int shieldBar;
    [Range(0, 10)] public int waveBar;

    [SerializeField] Image[] _fillBars = new Image[4];

    Dictionary<string, List<int>> _upgrades = new Dictionary<string, List<int>>();

    void Start()
    {
        playerStats = Player_Stats_Manager.instance;
        GetUpgradeLevel();
        SetBars();
        CreateUpgradeDictionary();
    }

    void SetBars()
    {
        _fillBars[0].fillAmount = (float)vitalityBar / 10;
        _fillBars[1].fillAmount = (float)damageBar / 10;
        _fillBars[2].fillAmount = (float)shieldBar / 10;
        _fillBars[3].fillAmount = (float)waveBar / 10;
    }

    void CreateUpgradeDictionary()
    {
        //nombre mejora = lista(precio base, multiplicador, nivel de barra)
        _upgrades["vitality"] = new List<int> { 10, 2, vitalityBar };
        _upgrades["damage"] = new List<int> { 10, 3, damageBar };
        _upgrades["shield"] = new List<int> { 20, 2, shieldBar };
        _upgrades["wave"] = new List<int> { 20, 2, waveBar };
    }

    public void CompleteBuyOperation(string statName)
    {
        if (!_upgrades.ContainsKey(statName)) return;

        if (_upgrades.TryGetValue(statName, out var list_values))
        {

            int price = (list_values[2] == 1) ? list_values[0] : list_values[0] * (int)Mathf.Pow(list_values[1], list_values[2] - 1);

            print("precio de compra: " + price);
            print("Nivel de stat: " + list_values[2]);

            if (UpgradePointsManager.instance.UpgradePoints < price) return;
            else
            {
                if (list_values[2] < 10)
                {
                    list_values[2]++;

                    switch (statName)
                    {
                        case "vitality":
                            vitalityBar = list_values[2];
                            UpdateUpgradeLevel("vitality", "+");
                            break;
                        case "damage":
                            damageBar = list_values[2];
                            UpdateUpgradeLevel("damage", "+");
                            break;
                        case "shield":
                            shieldBar = list_values[2];
                            UpdateUpgradeLevel("shield", "+");
                            break;
                        case "wave":
                            waveBar = list_values[2];
                            UpdateUpgradeLevel("wave", "+");
                            break;
                    }
                    SetBars();
                    UpgradePointsManager.instance.SpentUP(price);
                }
            }
        }
    }

    public void RefundUpgrade(string statName)
    {
        if (!_upgrades.ContainsKey(statName)) return;

        if (_upgrades.TryGetValue(statName, out var list_values))
        {

            int price = (list_values[2] == 1) ? 0 : list_values[0] * (int)Mathf.Pow(list_values[1], list_values[2] - 2);

            print("valor devuelto: " + price);
            print("Nivel de stat: " + list_values[2]);

            if (list_values[2] > 1)
            {
                list_values[2]--;

                switch (statName)
                {
                    case "vitality":
                        vitalityBar = list_values[2];
                        UpdateUpgradeLevel("vitality", "-");
                        break;
                    case "damage":
                        damageBar = list_values[2];
                        UpdateUpgradeLevel("damage", "-");
                        break;
                    case "shield":
                        shieldBar = list_values[2];
                        UpdateUpgradeLevel("shield", "-");
                        break;
                    case "wave":
                        waveBar = list_values[2];
                        UpdateUpgradeLevel("wave", "-");
                        break;
                }
                SetBars();
                UpgradePointsManager.instance.RefundUP(price);
            }
        }
    }

    void GetUpgradeLevel()
    {
        GameManager _gm = GameManager.instance;
        vitalityBar = _gm.upgradeBarLevel["vitality"];
        damageBar = _gm.upgradeBarLevel["damage"];
        shieldBar = _gm.upgradeBarLevel["shield"];
        waveBar = _gm.upgradeBarLevel["wave"];
    }

    void UpdateUpgradeLevel(string stat, string sign)
    {
        if (sign == "+")
        {
            GameManager.instance.upgradeBarLevel[stat]++;
            playerStats.LevelUpStat(stat);
        }
        else if (sign == "-")
        {
            GameManager.instance.upgradeBarLevel[stat]--;
            playerStats.LevelDownStat(stat);
        }
    }
}
