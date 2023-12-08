using System.Collections;
using UnityEngine;

public class StaminaManager : MonoBehaviour
{
    public static StaminaManager instance;
    Stamina _gameStamina;

    [SerializeField] int _maxStamina;
    int stamina;
    bool _canConsume;

    public int Stamina { get { return stamina; } }
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

    void Update() { if (Input.GetKeyUp(KeyCode.W)) RechargeStamina(); }

    void Initialize()
    {
        _gameStamina = new Stamina(_maxStamina);
        stamina = _gameStamina._maxStamina;
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