using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : IResources
{
    public float _actualCurrency;

    public Currency(float actualCurrency)
    {
        _actualCurrency = actualCurrency;
    }

    public void SpentResource(int quantity)
    {
        if (_actualCurrency < quantity) return;
        _actualCurrency -= quantity;
    }

    public void GainResource(int quantity)
    {
        var currencyGained = quantity * 0.8f * 0.7f;

        _actualCurrency += (int)currencyGained;
    }

    /*
    public void SpentCurrency(float currency)
    {
        _actualCurrency -= currency;
    }

    public void GainCurrency(float score)
    {
        var currencyGained = score * 0.8f * 0.7f;

        _actualCurrency += currencyGained;
    }
    */
}
