using Unity.VisualScripting;
using UnityEngine;

public class _currencyManager : MonoBehaviour
{
    public static _currencyManager instance;
    Currency _gameCurrency;

    [SerializeField] int currency;

    public int Currency { get { return currency; } set { currency = value; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Initialize();
        }
        else Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    void Initialize()
    {
        _gameCurrency = new Currency(PlayerPrefs.GetInt("currency"));
        currency = _gameCurrency.currency;
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