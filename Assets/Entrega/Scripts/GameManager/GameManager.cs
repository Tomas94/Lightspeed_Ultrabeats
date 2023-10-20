using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Currency _gameCurrency;
    public Stamina _gamestamina;
    public UpgradePoints _gameUpgradePoints;
    [SerializeField] public Score _levelScore;
    public float timer = 0;
    public int killcount = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            _gameCurrency = new Currency(0);
            _gamestamina = new Stamina(5);
            _gameUpgradePoints = new UpgradePoints(0);
            _levelScore = new Score();
            DontDestroyOnLoad(this);
        }
        else Destroy(gameObject);     
    }

    private void Update()
    {
        timer += Time.deltaTime;
        _levelScore.IncrementScore(timer);
        _levelScore.TotalScore();

        /*if(Input.GetKeyDown(KeyCode.Escape))
        {
           SceneChanger.ResetGame();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _gameCurrency.SpentResource(10);
            Debug.Log("current stamina: " + _gamestamina._currentStamina);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _gameCurrency.GainResource(20);
            Debug.Log("current stamina: " + _gamestamina._currentStamina);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _gamestamina.RefillStamina();
            Debug.Log("current stamina: " + _gamestamina._currentStamina);
        }*/
    }   
}
