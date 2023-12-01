using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    Currency _gameCurrency = new Currency(0);

    private void Start()
    {
        _gameCurrency._actualCurrency = GameManager.Instance.currency;
        GainCurrency(GameManager.Instance.levelScore);
    }

    public void SpentCurrency(int value)
    {
        _gameCurrency.SpentResource(value);
        UpdateCurrency();
    }

    public void GainCurrency(int value)
    {
        _gameCurrency.GainResource(value);
        UpdateCurrency();
    }

    void UpdateCurrency() => GameManager.Instance.currency = _gameCurrency._actualCurrency;
}