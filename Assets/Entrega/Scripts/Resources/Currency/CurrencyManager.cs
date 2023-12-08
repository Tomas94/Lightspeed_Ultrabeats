using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;
    Currency _gameCurrency = new Currency(0);

    [SerializeField] int currency;

    public int Currency {  get { return currency; } set { currency = value; } }

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    public void SpentCurrency(int value)
    {
        currency = _gameCurrency.SpentResource(value);
    }

    public void GainCurrency(int value)
    {
        currency = _gameCurrency.GainResource(value);
    }
}