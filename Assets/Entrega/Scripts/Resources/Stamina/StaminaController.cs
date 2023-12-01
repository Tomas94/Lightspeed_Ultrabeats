using System.Collections;
using UnityEngine;

public class StaminaController : MonoBehaviour
{
    Stamina _gameStamina;
    [SerializeField] int _maxStamina = 5;
    bool _canConsume = true;

    public int MaxStamina { get { return _maxStamina; } }

    private void Awake() { _gameStamina = new Stamina(_maxStamina); }

    void Start()
    {
        if (GameManager.Instance.stamina < 0) UpdateStamina();
        _gameStamina._currentStamina = GameManager.Instance.stamina;
    }

    void Update() { if (Input.GetKeyUp(KeyCode.W)) RechargeStamina(); }

    public void ConsumeStamina()
    {
        if (!_canConsume) return;

        _gameStamina.ConsumeStamina();
        UpdateStamina();
        StartCoroutine(ConsumeCD());
    }

    public void RechargeStamina()
    {
        _gameStamina.RechargeStamina();
        UpdateStamina();
    }

    public void RefillStamina()
    {
        _gameStamina.RefillStamina();
        UpdateStamina();
    }

    void UpdateStamina() => GameManager.Instance.stamina = _gameStamina._currentStamina;

    IEnumerator ConsumeCD()
    {
        _canConsume = false;
        yield return new WaitForSeconds(1f);
        _canConsume = true;
    }
}