using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Currency _gameCurrency;
    public Stamina _gamestamina;
    public UpgradePoints _gameUpgradePoints;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        
        _gameCurrency = new Currency(0);
        _gamestamina = new Stamina(5);
        _gameUpgradePoints = new UpgradePoints(0);
    }
}
