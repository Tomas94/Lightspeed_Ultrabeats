using System.Collections;
using UnityEngine;

public class StaminaManager : MonoBehaviour
{
    public static StaminaManager instance;
    Stamina _gameStamina;
    //public Timer _timer;

    [SerializeField] int _maxStamina;
    [SerializeField] int stamina;
    bool _canConsume;

    public int Stamina { get { return stamina; } set { stamina = value; } }
    public int MaxStamina { get { return _maxStamina; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Initialize();
        }
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    //void Update() { if (_timer.remainingTime <= 0) RechargeStamina(); }

    void Initialize()
    {
        _gameStamina = new Stamina(PlayerPrefs.GetInt("stamina"));
        stamina = _gameStamina._currentStamina;
        _canConsume = true;
    }

    public void ConsumeStamina()
    {
        if (!_canConsume) return;

        stamina = _gameStamina.ConsumeStamina();
        StartCoroutine(ConsumeCD());
    }

    public void RechargeStamina()
    {
        stamina = _gameStamina.RechargeStamina();
    }

    public void RefillStamina()
    {
        stamina = _gameStamina.RefillStamina();
    }

    IEnumerator ConsumeCD()
    {
        _canConsume = false;
        yield return new WaitForSeconds(3f);
        _canConsume = true;
    }
}