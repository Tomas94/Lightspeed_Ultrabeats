using UnityEngine;

public class Currency
{
    public int currency;

    public Currency(int _actualCurrency) => currency = _actualCurrency;

    public int SpentResource(int quantity)
    {
        if (currency < quantity) return currency;       
            Debug.Log("Gastando platita");
            currency -= quantity;
            return currency;            
    }

    public int GainResource(int quantity)
    {
        Debug.Log("Ganando Currency");
        var currencyGained = quantity * 0.8f * 0.7f;
        currency += (int)currencyGained;
        return currency;
    }
}
